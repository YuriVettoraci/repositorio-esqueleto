using Delivery.Infrastructure.Autenticacoes.Mapeamentos;
using FluentNHibernate.Cfg;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Ioc.Configuracoes
{
    internal static class ConfiguracaoNHibernate
    {
        public static IServiceCollection AddNHibernate(this IServiceCollection services, IWebHostEnvironment env, IConfiguration configuration)
        {
            services.AddSingleton<ISessionFactory>(f =>
            {
                return Fluently.Configure().Database(() =>
                {
                    string connectionString = configuration.GetConnectionString("MySql");

                    return FluentNHibernate.Cfg.Db.MySQLConfiguration.Standard.ConnectionString(connectionString).FormatSql().ShowSql().ConnectionString(connectionString);

                }).Mappings(m => m.FluentMappings.AddFromAssemblyOf<AutenticacaoMap>()).CurrentSessionContext("call").BuildSessionFactory();
            });

            services.AddScoped<ISession>(fac =>
            {
                return fac.GetService<ISessionFactory>().OpenSession();
            });

            return services;
        }
    }
}
