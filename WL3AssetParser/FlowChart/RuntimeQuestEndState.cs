using UnityAssetLib.Serialization;

namespace WL3AssetParser.FlowChart
{
    [UnitySerializable]
    public class RuntimeQuestEndState
    {
        public int EndStateID;

        public string DisplayName;

        public uint PackageID;
    }
}