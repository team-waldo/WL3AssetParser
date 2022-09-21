using System;
using System.IO;
using System.Linq;
using UnityAssetLib;
using UnityAssetLib.Serialization;
using UnityAssetLib.Types;

namespace CharacterGuidExtractor
{
    class Program
    {
        const string GameDataPath = @"D:\Steam\steamapps\common\Wasteland 3\WL3_Data";

        const string GameManagerFilename = "globalgamemanagers.assets";

        static void Main(string[] args)
        {
            var gameManagerPath = Path.Combine(GameDataPath, GameManagerFilename);

            long conversationSpeakerScriptId = -1;
            long speakerScriptId = -1;

            using (var assets = AssetsFile.Open(gameManagerPath))
            {
                conversationSpeakerScriptId = assets.GetAssetByName("ConversationSpeaker", ClassIDType.MonoScript).pathID;
                speakerScriptId = assets.GetAssetByName("Speaker", ClassIDType.MonoScript).pathID;
            }

            foreach (var filePath in Directory.GetFiles(GameDataPath, "*.assets", SearchOption.TopDirectoryOnly))
            {
                if (filePath.EndsWith(GameManagerFilename)) continue;

                using (var assets = AssetsFile.Open(filePath))
                {
                    var serializer = new UnitySerializer(assets);

                    var monobehaviours = assets.assets.Values.Where(x => x.ClassIDType == ClassIDType.MonoBehaviour);
                    foreach (var mbi in monobehaviours)
                    {
                        var scriptid = serializer.Deserialize<MonoBehaviour>(mbi, false).m_Script.m_PathID;

                        if (scriptid == conversationSpeakerScriptId)
                        {
                            var speaker = serializer.Deserialize<ConversationSpeaker>(mbi, false);
                            Console.WriteLine($"ConversationSpeaker={speaker.CharacterGuid}={speaker.m_Name}");
                        }

                        if (scriptid == speakerScriptId)
                        {
                            var speaker = serializer.Deserialize<ConversationSpeaker>(mbi, false);
                            Console.WriteLine($"Speaker={speaker.CharacterGuid}={speaker.m_Name}");
                        }
                    }
                }
            }
        }
    }
}
