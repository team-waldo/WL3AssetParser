using UnityAssetLib.Serialization;

namespace WL3AssetParser.FlowChart
{
    [UnitySerializable]
    public class RuntimeQuestEventTalk : RuntimeQuestEvent
    {
        public string Conversation;

        public int NodeID;
    }
}