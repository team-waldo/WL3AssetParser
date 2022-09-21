using UnityAssetLib.Serialization;

namespace WL3AssetParser.FlowChart
{
    [UnitySerializable]
    public class RuntimeConditionalNode : RuntimeFlowChartNode
    {
        public override FlowChartNodeType NodeType => FlowChartNodeType.Conditional;
    }
}