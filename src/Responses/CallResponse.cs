using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Gateway.PipeRun.Responses
{
    public class CallResponse : Response
    {
        #region EXEMPLO DE DADOS
        /*
        "id": 582133,
        "account_id": 1,
        "user_id": 1,
        "from_user_id": 1,
        "deal_id": 1891456,
        "company_id": null,
        "person_id": 705563,
        "webphone_id": 1,
        "webphone_extension_id": 1,
        "username": null,
        "from_number": "3016",
        "to_number": "55999999999",
        "record_audio": null,
        "from_caller_id": "3016",
        "to_caller_id": null,
        "description": null,
        "start_at": "2019-03-10 17:16:18",
        "end_at": "2019-03-10 17:19:35",
        "status": 200,
        "record_url": null,
        "external_call_id": 3572,
        "json_return": {
            "id": 582133,
            "start_at": "2019-03-10 17:16:18",
            "end_at": "2019-03-10 17:19:35",
            "status": 200,
            "record_url": null,
            "external_call_id": 3572,
            "duration": "00:03:17",
            "cost": 0.79
        },
        "important": null,
        "duration": "00:03:17",
        "cost": 0.79,
        "created_at": "2019-03-21 16:50:49",
        "updated_at": "2019-03-21 16:52:13"        
        */
        #endregion


        [JsonPropertyName("data")]
        public CallResponseData Data { get; set; } = default!;
    }
}
