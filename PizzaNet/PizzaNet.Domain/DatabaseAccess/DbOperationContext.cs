using System;

namespace PizzaNet.Domain.DatabaseAccess
{
    class DbOperationContext : IDisposable
    {
        public DbOperationContext(PizzaNetDbEntities context)
        {
            Context = context;
        }

        public PizzaNetDbEntities Context { get; private set; }
        public bool RequestRollback { get; set; }
        public bool IsDisposed { get; private set; }

        public void Dispose()
        {
            IsDisposed = true;
        }
    }
}