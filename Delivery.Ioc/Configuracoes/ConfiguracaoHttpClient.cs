using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Ioc.Configuracoes
{
    internal static class ConfiguracaoHttpClient
    {
        public static IServiceCollection AddHttpClient(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient("Exemplo.Api", client =>
            {
                client.BaseAddress = new Uri(configuration.GetSection("Exemplo:UrlExemplo").Value);
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            });

            return services;
        }
    }
}
