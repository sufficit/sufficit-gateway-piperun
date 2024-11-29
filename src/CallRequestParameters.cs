using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Gateway.PipeRun
{
    [DataContract]
    public class CallRequestParameters
    {
        [FromQuery(Name = "user")]
        [JsonPropertyName("user")]
        public string User {  get; set; } = default!;

        [FromQuery(Name = "pass")]
        [JsonPropertyName("pass")]
        public string Password { get; set; } = default!;

        [FromQuery(Name = "id_crm_call")]
        [JsonPropertyName("id_crm_call")]
        public string CallId { get; set; } = default!;

        [FromQuery(Name = "exten")]
        [JsonPropertyName("exten")]
        public string Extension { get; set; } = default!;

        [FromQuery(Name = "destination")]
        [JsonPropertyName("destination")]
        public string Destination { get; set; } = default!;
    }
}
