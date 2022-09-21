using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityAssetLib.Serialization;
using UnityAssetLib.Types;

namespace CharacterGuidExtractor
{
    [UnitySerializable]
    public class ConversationSpeaker : MonoBehaviour
    {
        public string CharacterGuid;
        public int gender;
    }
}
