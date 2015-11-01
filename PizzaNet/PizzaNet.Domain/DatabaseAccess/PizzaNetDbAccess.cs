using System;
using System.Threading.Tasks;
using System.Transactions;

namespace PizzaNet.Domain.DatabaseAccess
{
    class PizzaNetDbAccess : IPizzaNetDbAccess
    {
        public PizzaNetDbAccess(PizzaNetDbEntities entities)
        {
            _entities = entities;
        }

        ~PizzaNetDbAccess()
        {
            Dispose(false);
        }

        public bool IsDisposed { get; private set; }

        private object _transcationLock = new object();
        private PizzaNetDbEntities _entities;

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
                    using (var dbOperationContext = new DbOperationContext(_entities))
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