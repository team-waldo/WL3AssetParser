using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityAssetLib.Serialization;

namespace WL3AssetParser.FlowChart
{
    [UnitySerializable]
    public class RuntimeQuestData : RuntimeFlowChartData
	{
		public int QuestType;

		public RuntimeQuestEventAcquire[] acquireEvents;

		public RuntimeQuestEventGlobalVariable[] globalVariableEvents;

		public RuntimeQuestEventInspect[] inspectEvents;

		public RuntimeQuestEventInteract[] interactEvents;

		public RuntimeQuestEventKill[] killEvents;

		public RuntimeQuestEventLocation[] locationEvents;

		public RuntimeQuestEventTalk[] talkEvents;

		public int[] eventIndices;

		public int originPackage;
	}
}
