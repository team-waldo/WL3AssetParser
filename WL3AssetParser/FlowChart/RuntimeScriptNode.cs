using UnityAssetLib.Serialization;

namespace WL3AssetParser.FlowChart
{
    [UnitySerializable]
    public class RuntimeScriptNode : RuntimeDialogueNode
    {
        public bool IsAddPlayerNode;

        public bool ShouldIgnoreRangeWhenAddingPlayer;

        public override FlowChartNodeType NodeType => FlowChartNodeType.Script;
    }
}