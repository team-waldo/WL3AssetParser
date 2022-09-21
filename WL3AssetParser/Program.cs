using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using UnityAssetLib.Serialization;
using UnityAssetLib.Types;
using WL3AssetParser.FlowChart;

namespace WL3AssetParser
{
    class Program
    {
        static List<string> filenames = new();
        static List<RuntimeConversationData> conversations = new();

        static Dictionary<int, string> characterNames = new();
        static Dictionary<string, string> guidNames = new();

        static void Main(string[] args)
        {
            characterNames = LoadCharacterNames("data/stringtables_english.csv");
            guidNames = LoadCharacterGuids("data/guids.txt");

            ReadConversationData("data/main.dat");
            ReadConversationData("data/dlc1.dat");
            ReadConversationData("data/dlc2.dat");

            for (int i = 0; i< filenames.Count; i++)
            {
                var conv = conversations[i];
                var filename = filenames[i];

                foreach (var node in conv.GetDialogueNodes)
                {
                    node.NodeKey = $"{filename}/{node.NodeID}";
                }
            }

            for (int i = 0; i < filenames.Count; i++)
            {
                PreprocessNodes(conversations[i], filenames[i]);
            }

            var options = new JsonSerializerOptions
            {
                IncludeFields = true,
                WriteIndented = true,
                IgnoreReadOnlyFields = true,
                IgnoreReadOnlyProperties = true,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault,
            };

            options.Converters.Add(new JsonStringEnumConverter());
            options.Converters.Add(new SerializedGuidConverter());

            var joinedAsset = new ConversationStorageAsset()
            {
                conversationFileNames = filenames.ToArray(),
                conversations = conversations.ToArray(),
            };

            var json = JsonSerializer.Serialize(joinedAsset, options);

            File.WriteAllText("db.json", json);
        }

        static Dictionary<string, string> LoadCharacterGuids(string path)
        {
            var result = new Dictionary<string, string>();

            using var sr = new StreamReader(path);
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                var parts = line.Split('=', 3);
                string type = parts[0];
                string guid = parts[1];
                string value = parts[2];

                if (int.TryParse(value, out int characterid) && characterNames.TryGetValue(characterid, out string characterName))
                {
                    result.TryAdd(guid, characterName);
                }
                else
                {
                    result.TryAdd(guid, value);
                }
            }

            return result;
        }

        static Dictionary<int, string> LoadCharacterNames(string path)
        {
            using var sr = new StreamReader(path);
            var lines = Csv.CsvReader.Read(sr, new Csv.CsvOptions() { AllowNewLineInEnclosedFieldValues = true });
            return lines.Where(x => x[0] == "characters").ToDictionary(x => int.Parse(x[1]), x => x[2]);
        }

        static void ReadConversationData(string path)
        {
            var serializer = new UnitySerializer(new Version("2019.4.4.1"));

            var asset = serializer.Deserialize<ConversationStorageAsset>(File.ReadAllBytes(path));

            filenames.AddRange(asset.conversationFileNames);
            conversations.AddRange(asset.conversations);
        }

        static void PreprocessNodes(RuntimeConversationData conversationData, string conversationName)
        {
            if (conversationData.serializedNodes.bankNodes.Length != 0)
                Console.WriteLine(conversationName);

            var visitedNodeSet = new HashSet<int>();

            var nodeDict = conversationData.GetDialogueNodes.ToDictionary(x => x.NodeID);

            void FixBankNode(RuntimeBankNode bankNode)
            {
                if ((bankNode.BankNodePlayType == BankNodePlayType.FollowupPlayerQuestion || bankNode.BankNodePlayType == BankNodePlayType.FollowupTalkNode)
                    && bankNode.ChildNodeIDs.Count == bankNode.dialogueLinks.Length)
                {
                    for (int i = 0; i < bankNode.ChildNodeIDs.Count; i++)
                    {
                        var bankNodeLink = bankNode.dialogueLinks[i];
                        var childNodeId = bankNode.ChildNodeIDs[i];
                        var childNode = nodeDict[childNodeId];
                        if (childNode.dialogueLinks.Length != 0) throw new Exception();
                        childNode.dialogueLinks = new RuntimeDialogueLink[] { new RuntimeDialogueLink() { FromNodeID = childNodeId, ToNodeID = bankNodeLink.ToNodeID } };
                    }
                    bankNode.dialogueLinks = bankNode.ChildNodeIDs.Select(x => new RuntimeDialogueLink() { FromNodeID = bankNode.NodeID, ToNodeID = x }).ToArray();
                }
                else if (bankNode.BankNodePlayType == BankNodePlayType.PlayAll || bankNode.BankNodePlayType == BankNodePlayType.PlayAddenda)
                {
                    var exitLinks = bankNode.dialogueLinks;
                    RuntimeFlowChartNode currentNode = bankNode;

                    for (int i = 0; i < bankNode.ChildNodeIDs.Count; i++)
                    {
                        var childNodeId = bankNode.ChildNodeIDs[i];
                        var childNode = nodeDict[childNodeId];
                        if (childNode.dialogueLinks.Length != 0) throw new Exception();
                        currentNode.dialogueLinks = new RuntimeDialogueLink[] { new RuntimeDialogueLink() { FromNodeID = currentNode.NodeID, ToNodeID = childNodeId } };
                        currentNode = childNode;
                    }
                    currentNode.dialogueLinks = exitLinks;
                }
                else if (bankNode.BankNodePlayType == BankNodePlayType.FollowupPlayerQuestion ||
                         bankNode.BankNodePlayType == BankNodePlayType.FollowupTalkNode ||
                         bankNode.BankNodePlayType == BankNodePlayType.PlayFirst)
                {
                    var exitLinks = bankNode.dialogueLinks;
                    for (int i = 0; i < bankNode.ChildNodeIDs.Count; i++)
                    {
                        var childNodeId = bankNode.ChildNodeIDs[i];
                        var childNode = nodeDict[childNodeId];
                        if (childNode.dialogueLinks.Length != 0) throw new Exception();
                        childNode.dialogueLinks = exitLinks;
                    }
                    bankNode.dialogueLinks = bankNode.ChildNodeIDs.Select(x => new RuntimeDialogueLink() { FromNodeID = bankNode.NodeID, ToNodeID = x }).ToArray();
                }
                else if (bankNode.BankNodePlayType == BankNodePlayType.TideNode)
                {
                    bankNode.dialogueLinks = bankNode.ChildNodeIDs.Select(x => new RuntimeDialogueLink() { FromNodeID = bankNode.NodeID, ToNodeID = x }).ToArray();
                }
                else
                {
                    throw new NotImplementedException(bankNode.BankNodePlayType.ToString());
                }
            }

            void VisitNode(int nodeId, int prevNodeId, string speakerName = null)
            {
                if (visitedNodeSet.Contains(nodeId))
                    return;
                visitedNodeSet.Add(nodeId);
                if (!nodeDict.TryGetValue(nodeId, out var node))
                    return;
                node.PrevNode = prevNodeId;
                node.ConversationName = conversationName;

                const string setCovnersationSpeakerFunc = "Void SetConversationSpeakerDisplayName(Int32, FlowChartPlayer)";
                const string clearCovnersationSpeakerFunc = "Void ClearConversationSpeakerDisplayName(FlowChartPlayer)";

                RuntimeScriptCall setName = node.OnEnterScripts.FirstOrDefault(x => x.Data.FullName == setCovnersationSpeakerFunc);
                if (setName != default)
                {
                    speakerName = characterNames[int.Parse(setName.Data.Parameters[0])];
                }

                if (node is RuntimeTalkNode talkNode)
                {
                    if (!talkNode.SpeakerGuid.Equals(SerializedGuid.Empty) && guidNames.TryGetValue(talkNode.SpeakerGuid.ToString(), out string name))
                    {
                        talkNode.SpeakerName = name;
                    }
                    else
                    {
                        talkNode.SpeakerName = speakerName;
                    }
                }

                RuntimeScriptCall clearName = node.OnExitScripts.FirstOrDefault(x => x.Data.FullName == clearCovnersationSpeakerFunc);
                if (clearName != default)
                {
                    speakerName = null;
                }

                if (node is RuntimeBankNode bankNode)
                {
                    FixBankNode(bankNode);
                }

                foreach (var link in node.dialogueLinks)
                {
                    VisitNode(link.ToNodeID, nodeId, speakerName);
                }
            }

            VisitNode(0, -1);

            foreach (var node in nodeDict.Values)
            {
                if (node.ConversationName == default)
                    Console.WriteLine($"ConversationName is not set for node {conversationName}/{node.NodeID}");
            }
        }
    }
}
