using Delivery.Application.Autenticacoes.Profiles;
using Delivery.Ioc.Configuracoes;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Delivery.Ioc
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration, IWebHostEnvironment env)
        {
            services.AddHttpClient(configuration);

            services.AddNHibernate(env, configuration);

            services.AddInterfaces();

            services.AddAws(configuration, env);

            services.AddAutoMapper(typeof(AutenticacaoProfile).GetTypeInfo().Assembly);
        }
    }
}
