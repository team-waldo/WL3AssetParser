using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityAssetLib.Serialization;
using UnityAssetLib.Types;

using WL3AssetParser.FlowChart;

namespace WL3AssetParser
{
	[UnitySerializable]
	public class ConversationStorageAsset : MonoBehaviour
	{
		public string[] conversationFileNames;

		public RuntimeConversationData[] conversations;
	}
}
