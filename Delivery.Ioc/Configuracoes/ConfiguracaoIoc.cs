using Delivery.Application.Autenticacoes.Servicos;
using Delivery.Application.Autenticacoes.Servicos.Interfaces;
using Delivery.Domain.Utilitarios.Transacoes;
using Delivery.Infrastructure.Transacoes;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Ioc.Configuracoes
{
    internal static class ConfiguracaoIoc
    {
        public static IServiceCollection AddInterfaces(this IServiceCollection services)
        {
            services.AddScoped<IAutenticacaoAppServico, AutenticacaoAppServico>();

            services.AddSingleton<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
