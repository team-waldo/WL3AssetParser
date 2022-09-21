using System.Collections.Generic;
using UnityAssetLib.Serialization;

namespace WL3AssetParser.FlowChart
{
    [UnitySerializable]
    public class RuntimeQuestNode : RuntimeFlowChartNode
	{
		public bool IsTempText;

		public List<RuntimeQuestEndState> EndStates;

		public ExperienceType ExperienceType;

		public int ExperienceLevel;

		public override FlowChartNodeType NodeType => FlowChartNodeType.Quest;
    }

	public enum ExperienceType
	{
		Minor,
		Normal,
		Major
	}
}