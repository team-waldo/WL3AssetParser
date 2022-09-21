using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using UnityAssetLib.Serialization;

namespace WL3AssetParser.FlowChart
{
    [UnitySerializable]
    public class RuntimeConversationData : RuntimeFlowChartData
    {
        private List<RuntimeFlowChartNode> DialogueNodeCollection;

        [JsonIgnore]
        public List<RuntimeFlowChartNode> GetDialogueNodes
        {
            get 
            {
                if (DialogueNodeCollection is null)
                {
                    DialogueNodeCollection = new();

                    DialogueNodeCollection.AddRange(serializedNodes.bankNodes);
                    DialogueNodeCollection.AddRange(serializedNodes.chatterNodes);
                    DialogueNodeCollection.AddRange(serializedNodes.playerResponseNodes);
                    DialogueNodeCollection.AddRange(serializedNodes.scriptNodes);
                    DialogueNodeCollection.AddRange(serializedNodes.talkNodes);
                    DialogueNodeCollection.AddRange(serializedNodes.triggerConversationNodes);
                }

                return DialogueNodeCollection;
            }
        }
    }
}
