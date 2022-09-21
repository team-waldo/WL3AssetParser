using UnityAssetLib.Serialization;

namespace WL3AssetParser.FlowChart
{
    [UnitySerializable]
    public class RuntimeQuestEvent
    {
        public const int INVALID_EVENT_ID = -1;

        public int EventID;

        public string DisplayName;
    }
}