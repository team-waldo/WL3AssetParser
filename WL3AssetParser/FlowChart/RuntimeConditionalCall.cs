using UnityAssetLib.Serialization;

namespace WL3AssetParser.FlowChart
{
    [UnitySerializable]
    public class RuntimeConditionalCall : RuntimeExpressionComponent
    {
        public RuntimeScriptCallData Data;

        public bool Not;

        public LogicalOperator Operator;
    }
}