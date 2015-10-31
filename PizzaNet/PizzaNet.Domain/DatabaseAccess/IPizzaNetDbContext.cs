using System;
using System.Threading.Tasks;

namespace PizzaNet.Domain.DatabaseAccess
{
    interface IPizzaNetDbContext : IDisposable
    {
        bool IsDisposed { get; }

        void ExecuteInTransaction(Func<DbOperationContext> operation);

        T ExecuteInTransaction<T>(Func<DbOperationContext, T> operation);

        Task<T> ExecuteInTransactionAsync<T>(Func<DbOperationContext, T> operation);

        Task ExecuteInTransactionAsync(Func<DbOperationContext> operation);
    }
}
