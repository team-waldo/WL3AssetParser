using System.Text.Json.Serialization;
using UnityAssetLib.Serialization;

namespace WL3AssetParser.FlowChart
{
    [UnitySerializable]
    public class RuntimePlayerResponseNode : RuntimeDialogueNode
    {
        [JsonIgnore]
        public SerializedGuid RequiredListenerGuid;

        public override FlowChartNodeType NodeType => FlowChartNodeType.PlayerResponse;
    }
}