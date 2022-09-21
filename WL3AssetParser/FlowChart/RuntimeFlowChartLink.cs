using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityAssetLib.Serialization;

namespace WL3AssetParser.FlowChart
{
    [UnitySerializable]
    public class RuntimeFlowChartLink
    {
        public int FromNodeID;

        public int ToNodeID;

        public bool PointsToGhost;

        public class RuntimeFlowChartEqualityComparer : IEqualityComparer<RuntimeFlowChartLink>
        {
            public bool Equals(RuntimeFlowChartLink x, RuntimeFlowChartLink y)
            {
                return x.FromNodeID == y.FromNodeID && x.ToNodeID == y.ToNodeID;
            }

            public int GetHashCode([DisallowNull] RuntimeFlowChartLink obj)
            {
                return HashCode.Combine(obj.FromNodeID, obj.ToNodeID, obj.PointsToGhost);
            }
        }
    }
}
