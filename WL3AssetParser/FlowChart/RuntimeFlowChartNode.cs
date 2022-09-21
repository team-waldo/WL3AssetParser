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
    public abstract class RuntimeFlowChartNode
	{
		public const int INVALID_NODE_ID = -1;

		public int NodeID;

		[JsonIgnore]
		public uint PackageID;

		[JsonIgnore]
		public int ContainerNodeID;

		[JsonIgnore]
		public RuntimeFlowChartLink[] flowChartLinks;

		public RuntimeDialogueLink[] dialogueLinks;

		[JsonIgnore]
		public RuntimeQuestLink[] questLinks;

		[JsonIgnore]
		public int[] linkIndices;

		[JsonIgnore]
		public bool NeverSaved;

		[JsonIgnore]
		public SerializedConditionalExpressionData serializedConditionals;

		[JsonIgnore]
		public List<RuntimeScriptCall> OnEnterScripts;

		[JsonIgnore]
		public List<RuntimeScriptCall> OnExitScripts;

		[JsonIgnore]
		public List<RuntimeScriptCall> OnUpdateScripts;
		
		public string ConversationName { get; set; }

		public int PrevNode { get; set; }

		public string NodeKey { get; set; }

		public abstract FlowChartNodeType NodeType { get; }
	}
}
