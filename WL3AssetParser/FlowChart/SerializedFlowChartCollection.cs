using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityAssetLib.Serialization;

namespace WL3AssetParser.FlowChart
{
    [UnitySerializable]
    public class SerializedFlowChartCollection
	{
		public RuntimeEndNode[] endNodes;

		public RuntimeChatterNode[] chatterNodes;

		public RuntimePlayerResponseNode[] playerResponseNodes;

		public RuntimeScriptNode[] scriptNodes;

		public RuntimeTalkNode[] talkNodes;

		public RuntimeTriggerConversationNode[] triggerConversationNodes;

		public RuntimeObjectiveNode[] objectiveNodes;

		public RuntimeBankNode[] bankNodes;

		public RuntimeConditionalNode[] conditionalNodes;

		public RuntimeQuestNode[] questNodes;
	}
}
