using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityAssetLib.Serialization;

namespace WL3AssetParser.FlowChart
{
	[UnitySerializable]
	public class RuntimeQuestLink : RuntimeFlowChartLink
	{
		public bool RequiredToExitObjective;
	}
}
