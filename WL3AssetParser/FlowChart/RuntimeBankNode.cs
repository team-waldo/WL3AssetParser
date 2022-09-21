using System.Collections.Generic;
using UnityAssetLib.Serialization;

namespace WL3AssetParser.FlowChart
{
    [UnitySerializable]
    public class RuntimeBankNode : RuntimeFlowChartNode
    {
        public BankNodePlayType BankNodePlayType;

        public List<int> ChildNodeIDs;

		public override FlowChartNodeType NodeType => FlowChartNodeType.Bank;
    }

	public enum BankNodePlayType
	{
		PlayFirst,
		PlayAll,
		PlayAddenda,
		FollowupPlayerQuestion,
		FollowupTalkNode,
		TideNode
	}
}