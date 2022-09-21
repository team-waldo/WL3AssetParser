using UnityAssetLib.Serialization;

namespace WL3AssetParser.FlowChart
{
    [UnitySerializable]
    public class RuntimeChatterNode : RuntimeDialogueNode
    {
        public override FlowChartNodeType NodeType => FlowChartNodeType.Chatter;
    }
}