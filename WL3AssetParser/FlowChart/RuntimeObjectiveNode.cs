using System.Collections.Generic;
using UnityAssetLib.Serialization;

namespace WL3AssetParser.FlowChart
{
	[UnitySerializable]
	public class RuntimeObjectiveNode : RuntimeFlowChartNode
	{
		public bool IsTempText;

		public List<int> AddendumIDs;

		public int ExperienceWeight;

		public override FlowChartNodeType NodeType => FlowChartNodeType.Objective;
    }
}