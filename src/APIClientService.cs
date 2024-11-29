using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Sufficit.Gateway.PipeRun.Responses;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Sufficit.Gateway.PipeRun
{
    public class APIClientService : ControllerSection
    {
        public const string VERSION = "v1";

        #region STATUS MONITOR

        /// <summary>
        ///     Last timestamp for health checked
        /// </summary>
        public DateTime HealthChecked { get; internal set; }

        /// <summary>
        ///     Sets a value for health status, used internal. <br />
        ///     Or you can set a custom value for testing purposes
        /// </summary>
        public void Healthy(bool value = true)
        {
            // updating timestamp
            HealthChecked = DateTime.UtcNow;

            if (Available != value)
            {
                Available = value;
                OnChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1);

        /// <summary>
        ///     Used on component initialization for ensure ready status
        /// </summary>
        public async Task GetStatus()
        {
            await _semaphore.WaitAsync();
            if (HealthChecked == DateTime.MinValue || DateTime.UtcNow.Subtract(HealthChecked).TotalMinutes > 30)
                _ = await Health(default);

            _semaphore.Release();
        }

        public bool Available { get; private set; }

        public async Task<bool> Health(CancellationToken cancellationToken)
        {
            bool status = false;
            try
            {
                var response = await httpClient.GetAsync("/", cancellationToken);
                status = response != null && response.IsSuccessStatusCode;
            }
            catch { }

            Healthy(status);
            return status;
        }

        #endregion

        // Used for compare changes
        private string BaseUrl { get; set; }

        /// <summary>
        ///     Status changed
        /// </summary>
        public event EventHandler? OnChanged;

        protected void OnOptionsChanged(GatewayOptions value, string? instance)
        {
            if (BaseUrl != value.BaseUrl)
            {
                BaseUrl = value.BaseUrl;
                HealthChecked = DateTime.MinValue;
            }
        }
        public APIClientService(IOptionsMonitor<GatewayOptions> ioptions, IHttpClientFactory clientFactory, ILogger<APIClientService> logger)
            : base(ioptions, clientFactory, logger, Json.Options)
        {
            BaseUrl = ioptions.CurrentValue.BaseUrl;
            ioptions.OnChange(OnOptionsChanged);

            logger.LogTrace("Sufficit PipeRun Gateway API Client Service instantiated with base address: {url}", options.BaseUrl);            
        }

        public async Task<CallResponse?> UpdateCallDetails(CallDetailsParameters parameters, CancellationToken cancellationToken)
        {
            var ep = "/webhooks/webphones";
            var uri = new Uri($"{VERSION}{ep}/{options.Token}", UriKind.Relative);

            var message = new HttpRequestMessage(HttpMethod.Post, uri);
            message.Content = JsonContent.Create(parameters, null, jsonOptions);

            using var response = await httpClient.SendAsync(message, cancellationToken);
            await response.EnsureSuccess(cancellationToken);

            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                return null;

            var text = await response.Content.ReadAsStringAsync();
            Console.WriteLine(text);
                        
            return JsonSerializer.Deserialize<CallResponse>(text);
        }
    }
}
