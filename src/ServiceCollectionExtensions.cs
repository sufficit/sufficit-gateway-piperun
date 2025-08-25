using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using System;

namespace Sufficit.Gateway.PipeRun
{
    public static partial class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSufficitGatewayPipeRun(this IServiceCollection services, IConfiguration configuration, ILoggerFactory? factory = null)
        {
            services.AddOptions<GatewayOptions>();

            // Definindo o local da configuração global
            // Importante ser dessa forma para o sistema acompanhar as mudanças no arquivo de configuração em tempo real 
            services.Configure<GatewayOptions>(configuration.GetSection(GatewayOptions.SECTIONNAME));

            // Capturando para uso local
            var options = configuration.GetSection(GatewayOptions.SECTIONNAME).Get<GatewayOptions>() ?? new GatewayOptions();

            services.AddTransient<ProtectedApiQueryTokenHandler>();
            services.AddHttpClient(options.ClientId, client => client.Configure(options)).AddHttpMessageHandler<ProtectedApiQueryTokenHandler>();

            services.AddSingleton<APIClientService>();
            return services;
        }
    }
}
