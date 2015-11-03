using System;
using System.Threading.Tasks;

namespace Pizza.Net.Domain.DatabaseAccess
{
    public interface IPizzaNetDbAccess
    {
        void ExecuteInTransaction(Action<DbOperationContext> operation);

        T ExecuteInTransaction<T>(Func<DbOperationContext, T> operation);

        Task<T> ExecuteInTransactionAsync<T>(Func<DbOperationContext, T> operation);

        Task ExecuteInTransactionAsync(Action<DbOperationContext> operation);
    }
}