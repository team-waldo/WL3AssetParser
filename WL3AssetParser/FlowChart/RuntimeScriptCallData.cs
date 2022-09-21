using System.Collections.Generic;
using UnityAssetLib.Serialization;

namespace WL3AssetParser.FlowChart
{
    [UnitySerializable]
    public class RuntimeScriptCallData
    {
        public bool HasDifficultTaskAttribute;

        public string FullName;

        public List<string> Parameters;
    }
}