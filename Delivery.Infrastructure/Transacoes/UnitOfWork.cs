using Delivery.Domain.Utilitarios.Transacoes;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Infrastructure.Transacoes
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private ISession session;
        private ITransaction transaction;

        public UnitOfWork(ISession session)
        {
            this.session = session;
        }

        public void Dispose()
        {
            if (transaction != null)
            {
                transaction.Dispose();
                transaction = null;
            }

            if(session != null && session.IsOpen)
            {
                session.Close();
                session = null;
            }
        }

        public void BeginTransaction()
        {
            transaction = session.BeginTransaction();
        }

        public void Commit()
        {
            if (transaction != null && transaction.IsActive)
                transaction.Commit();
        }

        public void Flush()
        {
            session?.Flush();
        }

        public void Rollback()
        {
            if (transaction != null && transaction.IsActive)
                transaction.Rollback();
        }
    }
}
