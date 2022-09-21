using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using UnityAssetLib.Serialization;

namespace WL3AssetParser.FlowChart
{
	[UnitySerializable]
	public class RuntimeDialogueLink : RuntimeFlowChartLink
	{
		[JsonIgnore]
		public int RandomWeight;

		[JsonIgnore]
		public QuestionNodeDisplayType QuestionNodeTextDisplay;

		[JsonIgnore]
		public SuccessType TypeOfSuccess;
	}

	public enum QuestionNodeDisplayType
	{
		ShowOnce,
		ShowAlways,
		ShowNever
	}

	public enum SuccessType
	{
		None,
		Success,
		Failure,
		CriticalSuccess,
		CriticalFailure
	}
}
