using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace Sufficit.Gateway.PipeRun
{
    public class DateTimeCustomJsonConverter : JsonConverter<DateTime>
    {
        public override DateTime Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options) =>
                DateTime.ParseExact(reader.GetString()!,
                    "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);

        public override void Write(
            Utf8JsonWriter writer,
            DateTime dateTimeValue,
            JsonSerializerOptions options) =>
                writer.WriteStringValue(dateTimeValue.ToString(
                    "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture));
    }
}
