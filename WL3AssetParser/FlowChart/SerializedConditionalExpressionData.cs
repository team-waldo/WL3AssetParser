using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityAssetLib.Serialization;

namespace WL3AssetParser.FlowChart
{
	[UnitySerializable]
	public class SerializedConditionalExpressionData
	{
		public ExpressionNodeData[] conditionalExpressions;

		public ExpressionNodeType[] allNodes;

		public RuntimeConditionalCall[] conditionalCalls;

		public bool isNull;
	}

	public enum ExpressionNodeType : byte
	{
		ConditionalExpression,
		ConditionalCall
	}
}
