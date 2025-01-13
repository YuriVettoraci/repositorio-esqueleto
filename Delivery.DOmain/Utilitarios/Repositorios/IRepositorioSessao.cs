using Delivery.Domain.Utilitarios.Consultas;
using Delivery.Domain.Utilitarios.Enumeradores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Domain.Utilitarios.Repositorios
{
    public interface IRepositorioSessao<T> where T : class
    {
        IQueryable<T> Query();
        Task InserirAsync(T entidade, CancellationToken cancellationToken = default);
        Task InserirAsync(IEnumerable<T> entidades, CancellationToken cancellationToken = default);
        Task ExcluirAsync(T entidade, CancellationToken cancellationToken = default(CancellationToken));
        Task ExcluirAsync(IEnumerable<T> entidades, CancellationToken cancellationToken = default(CancellationToken));
        Task<T> RecuperarAsync(int id, CancellationToken cancellationToken = default(CancellationToken));
        Task EditarAsync(T entidade, CancellationToken cancellationToken = default(CancellationToken));
        Task<T> RecuperarAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default(CancellationToken));
        Task<PaginacaoConsulta<T>> ListarAsync(IQueryable<T> query, Expression<Func<T, bool>> expression, int qt, int pg, string cpOrd, OrdemRegistrosEnum ordReg, CancellationToken cancellationToken);
    }
}
