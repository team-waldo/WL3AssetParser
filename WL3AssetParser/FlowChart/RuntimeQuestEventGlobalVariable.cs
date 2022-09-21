using UnityAssetLib.Serialization;

namespace WL3AssetParser.FlowChart
{
    [UnitySerializable]
    public class RuntimeQuestEventGlobalVariable : RuntimeQuestEvent
    {
        public string VariableName;

        public int VariableValue;
    }
}