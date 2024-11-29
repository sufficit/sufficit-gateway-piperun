using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Gateway.PipeRun.Responses
{
    public class CallResponseData : CallDetailsParameters
    {
        public int account_id { get; set; } = default!;


        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public int user_id { get; set; }


        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public int from_user_id { get; set; }


        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public int deal_id { get; set; }


        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public int? company_id { get; set; }


        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public int? person_id { get; set; }


        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public int webphone_id { get; set; }


        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public int? webphone_extension_id { get; set; }


        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? username { get; set; }


        [JsonConverter(typeof(BooleanCustomJsonConverter))]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? record_audio { get; set; }

        [JsonConverter(typeof(DateTimeCustomJsonConverter))]
        public DateTime created_at { get; set; }

        [JsonConverter(typeof(DateTimeCustomJsonConverter))]
        public DateTime updated_at { get; set; }

        public object? json_return { get; set; }

        [JsonConverter(typeof(BooleanCustomJsonConverter))]
        public bool? running_ai { get; set; }
    }
}
