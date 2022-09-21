using UnityAssetLib.Serialization;

namespace WL3AssetParser.FlowChart
{
    [UnitySerializable]
    public class RuntimeQuestEventLocation : RuntimeQuestEvent
    {
        public string TriggerObject;
    }
}