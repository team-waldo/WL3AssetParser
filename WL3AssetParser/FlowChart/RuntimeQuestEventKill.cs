using UnityAssetLib.Serialization;

namespace WL3AssetParser.FlowChart
{
    [UnitySerializable]
    public class RuntimeQuestEventKill : RuntimeQuestEvent
    {
        public string Target;

        public int TotalToKill;
    }
}