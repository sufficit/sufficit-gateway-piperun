using System;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace Sufficit.Gateway.PipeRun
{
    public class BooleanCustomJsonConverter : JsonConverter<bool?>
    {
        public override bool? Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options)
        {
            // as number
            if (reader.TokenType == JsonTokenType.Number) { 
                var content = reader.GetInt16();
                return content > 0;
            }

            if (reader.TokenType == JsonTokenType.True)
                return true;

            if (reader.TokenType == JsonTokenType.False)
                return false;

            {
                var content = reader.GetString();
                if (content == null || content == "null") return null;
                else if (int.TryParse(content, out int value))
                {
                    return value != 0;
                }
                else return Convert.ToBoolean(content);
            }
        }

        public override void Write(
            Utf8JsonWriter writer,
            bool? content,
            JsonSerializerOptions options)
        {
            if (content.HasValue)
            {
                if (content.Value)
                    writer.WriteNumberValue(1);
                else
                    writer.WriteNumberValue(0);
            }                
            else writer.WriteNullValue();
        }
    }
}
