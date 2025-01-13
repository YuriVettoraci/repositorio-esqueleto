using Delivery.Domain.Utilitarios.Consultas;
using Delivery.Domain.Utilitarios.Enumeradores;
using NHibernate;
using NHibernate.Linq;
using System.Linq;
using System.Linq.Expressions;
using System.Linq.Dynamic.Core;
using System.Linq.Dynamic.Core.Exceptions;
using Delivery.Domain.Utilitarios.Repositorios;

namespace Delivery.Infrastructure.Utilitarios
{
    public class RepositorioSessao<T> : IRepositorioSessao<T> where T : class
    {
        protected readonly ISession session;

        public RepositorioSessao(ISession session)
        {
            this.session = session;
        }

        public async Task InserirAsync(T entidade, CancellationToken cancellationToken = default(CancellationToken))
        {
            await session.SaveAsync(entidade, cancellationToken);
        }

        public async Task InserirAsync(IEnumerable<T> entidades, CancellationToken cancellationToken = default(CancellationToken))
        {
            foreach (T entidade in entidades)
            {
                await session.SaveAsync(entidade, cancellationToken);
            }
        }

        public async Task ExcluirAsync(T entidade, CancellationToken cancellationToken = default(CancellationToken))
        {
            await session.DeleteAsync(entidade, cancellationToken);
        }

        public async Task ExcluirAsync(IEnumerable<T> entidades, CancellationToken cancellationToken = default(CancellationToken))
        {
            foreach(T entidade in entidades)
            {
                await session.DeleteAsync(entidade, cancellationToken);
            }
        }

        public async Task<T> RecuperarAsync(int id, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await session.GetAsync<T>(id, cancellationToken);
        }

        public async Task EditarAsync(T entidade, CancellationToken cancellationToken = default(CancellationToken))
        {
            await session.UpdateAsync(entidade, cancellationToken);
        }

        public IQueryable<T> Query()
        {
            return session.Query<T>();
        }

        public async Task<T> RecuperarAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Query().Where(expression).SingleOrDefaultAsync(cancellationToken);
        }

        public async Task<PaginacaoConsulta<T>> ListarAsync(IQueryable<T> query, Expression<Func<T, bool>> expression, int qt, int pg, string cpOrd, OrdemRegistrosEnum ordReg, CancellationToken cancellationToken)
        {
            try
            {
                query = query.OrderBy(cpOrd + " " + ordReg);
                return await PaginarAsync(query, qt, pg, cancellationToken);
            }
            catch (ParseException)
            {
                throw;
            }
        }

        private static async Task<PaginacaoConsulta<T>> PaginarAsync(IQueryable<T> query, int qt, int pg, CancellationToken cancellationToken)
        {
            PaginacaoConsulta<T> paginacaoConsulta = new PaginacaoConsulta<T>();
            PaginacaoConsulta<T> paginacaoConsulta2 = paginacaoConsulta;
            paginacaoConsulta2.Registros = await query.Skip(qt * (pg - 1)).Take(qt).ToListAsync(cancellationToken);
            paginacaoConsulta.Total = query.LongCount();
            return paginacaoConsulta;
        }
    }
}
