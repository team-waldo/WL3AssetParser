using System;
using System.Text.Json.Serialization;
using UnityAssetLib.Serialization;

namespace WL3AssetParser.FlowChart
{
    [UnitySerializable]
    public class RuntimeTalkNode : RuntimeDialogueNode
	{
		[JsonIgnore]
		public string ActorDirection;

		public SerializedGuid SpeakerGuid;

		[JsonIgnore]
		public SerializedGuid AdditionalSpeaker1Guid;

		[JsonIgnore]
		public SerializedGuid AdditionalSpeaker2Guid;

		[JsonIgnore]
		public SerializedGuid AdditionalSpeaker3Guid;

		[JsonIgnore]
		public SerializedGuid ListenerGuid;

		[NonSerialized]
		public string SpeakerName;

		public override FlowChartNodeType NodeType => FlowChartNodeType.Talk;
    }
}