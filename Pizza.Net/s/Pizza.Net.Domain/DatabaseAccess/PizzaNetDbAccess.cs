using System;
using System.Threading.Tasks;
using System.Transactions;

namespace Pizza.Net.Domain.DatabaseAccess
{
    public class PizzaNetDbAccess : IPizzaNetDbAccess
    {
        public PizzaNetDbAccess()
        {
        }

        public bool IsDisposed { get; private set; }

        private object _transcationLock = new object();

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
                    using (var entities = new PizzaNetEntities())
                    {
                        using (var dbOperationContext = new DbOperationContext(entities))
                        {
                            T result = operation(dbOperationContext);
                            if (!dbOperationContext.RequestRollback)
                            {
                                entities.SaveChanges();
                                transactionScope.Complete();
                            }
                            return result;
                        }
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
    }
}