using UnityAssetLib.Serialization;

namespace WL3AssetParser.FlowChart
{
    [UnitySerializable]
    public class RuntimeTriggerConversationNode : RuntimeDialogueNode
    {
        public string ConversationFilename;

        public int StartNodeID;

        public override FlowChartNodeType NodeType => FlowChartNodeType.TriggerConversation;
    }
}
