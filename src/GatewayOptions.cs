using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sufficit.Gateway.PipeRun
{
    public class GatewayOptions
    {
        public const string SECTIONNAME = nameof(PipeRun);

        public string BaseUrl { get; set; } = "https://api.pipe.run";

        public string ClientId { get; set; } = SECTIONNAME;

        /// <summary>
        /// Default TimeOut (seconds) for endpoints requests 
        /// </summary>
        public uint? TimeOut { get; set; }

        public string Agent { get; set; } = "Sufficit C# API Client";

        /// <summary>
        ///     Given by PipeRun to authenticate your requests
        /// </summary>
        public string Token { get; set; } = default!;
    }
}
