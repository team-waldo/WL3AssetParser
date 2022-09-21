using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using WL3AssetParser.FlowChart;

namespace WL3AssetParser
{
    class SerializedGuidConverter : JsonConverter<SerializedGuid>
    {
        public override SerializedGuid Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string guidStr = reader.GetString();
            Guid guid = new Guid(guidStr);
            return new SerializedGuid(guid);
        }

        public override void Write(Utf8JsonWriter writer, SerializedGuid value, JsonSerializerOptions options)
        {
            Guid guid = value.ToGuid();
            string guidStr = guid.ToString();
            writer.WriteStringValue(guidStr);
        }
    }
}
