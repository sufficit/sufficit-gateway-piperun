using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Sufficit.Gateway.PipeRun
{
    public class CallDetailsParameters
    {
        [JsonPropertyOrder(-1)]
        public int id { get; set; } = default!;

        [JsonConverter(typeof(DateTimeCustomJsonConverter))]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public DateTime start_at { get; set; }

        [JsonConverter(typeof(DateTimeCustomJsonConverter))]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public DateTime? end_at { get; set; }

        /// <summary>
        /// 200 or 404
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public int? status { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? record_url { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? external_call_id { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public TimeSpan? duration { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public decimal? cost { get; set; }

        #region EXTENDED OPTIONS - NOT LISTED AT DOCUMENTATION


        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? description { get; set; }


        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? from_caller_id { get; set; }


        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? to_caller_id { get; set; }

        /// <summary>
        ///     Text only (used to show internal piperun extension)
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? from_number { get; set; }

        /// <summary>
        ///     Clickable link to dial again
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? to_number { get; set; }

        [JsonConverter(typeof(BooleanCustomJsonConverter))]
        [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        public bool? important { get; set; }

        #endregion
    }
}
