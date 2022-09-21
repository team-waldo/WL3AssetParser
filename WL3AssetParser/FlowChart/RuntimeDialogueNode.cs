using System.Text.Json.Serialization;
using UnityAssetLib.Serialization;

namespace WL3AssetParser.FlowChart
{
    [UnitySerializable]
    public abstract class RuntimeDialogueNode : RuntimeFlowChartNode
	{
		[JsonIgnore]
		public bool NotSkippable;

		[JsonIgnore]
		public bool IsCinematic;

		[JsonIgnore]
		public bool IsQuestionNode;

		[JsonIgnore]
		public bool IsTempText;

		[JsonIgnore]
		public PlayType PlayType;

		[JsonIgnore]
		public PersistenceType Persistence;

		[JsonIgnore]
		public uint NoPlayRandomWeight;

		[JsonIgnore]
		public float VoiceOverDelay;

		[JsonIgnore]
		public DisplayType DisplayType;
	}

	public enum PlayType
	{
		Normal,
		Random,
		CycleLoop,
		CycleStop
	}

	public enum PersistenceType
	{
		None,
		OnceEver,
		OncePerConversation,
		MarkAsRead
	}

	public enum DisplayType
	{
		Hidden,
		Conversation,
		Bark
	}
}