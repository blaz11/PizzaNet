using PizzaNet.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace PizzaNet.Domain.DatabaseAccess
{
    class PizzaNetDbContext : IPizzaNetDbContext
    {
        public PizzaNetDbContext()
        {

        }


        ~PizzaNetDbContext()
        {
            Dispose(false);
        }

        public bool IsDisposed { get; private set; }

        //TODO(bkula): Investigate if we really need it, maybe db takes care of isolation for us.
        private object _transcationLock = new object();
        private IPizzaNetEntities _entities;

        public void ExecuteInTransaction(Func<DbOperationContext> operation)
        {
            throw new NotImplementedException();
        }

        public T ExecuteInTransaction<T>(Func<DbOperationContext, T> operation)
        {
            throw new NotImplementedException();
        }

        public Task<T> ExecuteInTransactionAsync<T>(Func<DbOperationContext, T> operation)
        {
            return Task.Run(() => ExecuteInTransaction(operation));
        }

        public Task ExecuteInTransactionAsync(Func<DbOperationContext> operation)
        {
            return Task.Run(() => ExecuteInTransaction(operation));
        }

        public void Dispose()
        {
            Dispose(true);
        }

        private void Dispose(bool disposing)
        {
            if (disposing && !IsDisposed)
            {
                _entities.Dispose();
                IsDisposed = true;
                GC.SuppressFinalize(this);
            }
        }
    }
}
