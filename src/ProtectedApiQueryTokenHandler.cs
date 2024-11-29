using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Sufficit.Gateway.PipeRun
{
    public class ProtectedApiQueryTokenHandler : DelegatingHandler
    {
        private readonly GatewayOptions _options;
        public ProtectedApiQueryTokenHandler(IOptions<GatewayOptions> options) { _options = options.Value; }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (ShouldAuthenticate(request)) 
                Authenticate(request);

            // Proceed calling the inner handler, that will actually send the request
            // to our protected api
            return await base.SendAsync(request, cancellationToken);
        }

        protected void Authenticate(HttpRequestMessage request)
        {
            var uri = request.RequestUri?.ToString();
            if (!string.IsNullOrWhiteSpace(uri))
            {
                if (uri!.Contains(":token"))
                {
                    uri = uri.Replace(":token", _options.Token);
                    request.RequestUri = new Uri(uri);
                    return;
                }
            }

            if (!request.Headers.Contains("token"))
                request.Headers.Add("token", _options.Token);
        }

        protected bool ShouldAuthenticate(HttpRequestMessage request)
        {
            switch (request.RequestUri?.AbsolutePath)
            {
                // case "/contact":
                default: return true;
            }
        }
    }
}
