using System;
using System.Threading.Tasks;

namespace PizzaNet.Domain.DatabaseAccess
{
    interface IPizzaNetDbAccess : IDisposable
    {
        bool IsDisposed { get; }

        void ExecuteInTransaction(Action<DbOperationContext> operation);

        T ExecuteInTransaction<T>(Func<DbOperationContext, T> operation);

        Task<T> ExecuteInTransactionAsync<T>(Func<DbOperationContext, T> operation);

        Task ExecuteInTransactionAsync(Action<DbOperationContext> operation);
    }
}
