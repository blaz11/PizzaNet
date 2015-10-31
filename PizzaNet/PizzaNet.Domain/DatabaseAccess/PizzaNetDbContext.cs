using PizzaNet.Domain.Entities;
using System;
using System.Threading.Tasks;
using System.Transactions;

namespace PizzaNet.Domain.DatabaseAccess
{
    class PizzaNetDbContext : IPizzaNetDbContext
    {
        public PizzaNetDbContext(IPizzaNetEntities entities)
        {
            _entities = entities;
        }

        ~PizzaNetDbContext()
        {
            Dispose(false);
        }

        public bool IsDisposed { get; private set; }

        //TODO(bkula): Investigate if we really need it, maybe db takes care of isolation for us.
        private object _transcationLock = new object();
        private IPizzaNetEntities _entities;

        public void ExecuteInTransaction(Action<DbOperationContext> operation)
        {
            ExecuteInTransaction(dbOperationContext =>
            {
                operation(dbOperationContext);
                return 0;
            });
        }

        public T ExecuteInTransaction<T>(Func<DbOperationContext, T> operation)
        {
            lock (_transcationLock)
            {
                using (var transactionScope = new TransactionScope())
                {
                    using (var dbOperationContext = new DbOperationContext(this, _entities))
                    {
                        T result = operation(dbOperationContext);
                        if (!dbOperationContext.RequestRollback)
                        {
                            _entities.SaveChanges();
                            transactionScope.Complete();
                        }
                        return result;
                    }
                }
            }
        }

        public Task<T> ExecuteInTransactionAsync<T>(Func<DbOperationContext, T> operation)
        {
            return new Task<T>(() => ExecuteInTransaction(operation));
        }

        public Task ExecuteInTransactionAsync(Action<DbOperationContext> operation)
        {
            return new Task(() => ExecuteInTransaction(operation));
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