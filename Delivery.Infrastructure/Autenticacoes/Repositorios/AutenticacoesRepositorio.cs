using Delivery.Domain.Autenticacoes.Entidades;
using Delivery.Domain.Autenticacoes.Repositorios;
using Delivery.Infrastructure.Utilitarios;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Infrastructure.Autenticacoes.Repositorios
{
    public class AutenticacoesRepositorio : RepositorioSessao<Autenticacao>, IAutenticacoesRepositorio
    {
        public AutenticacoesRepositorio(ISession session) : base(session)
        {
        }
    }
}
