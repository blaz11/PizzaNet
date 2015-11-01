using System;

namespace Pizza.Net.Domain.DatabaseAccess
{
    public class DbOperationContext : IDisposable
    {
        public DbOperationContext(PizzaNetDatabaseEntities entities)
        {
            Entities = entities;
        }

        public PizzaNetDatabaseEntities Entities { get; private set; }
        public bool RequestRollback { get; set; }
        public bool IsDisposed { get; private set; }

        public void Dispose()
        {
            IsDisposed = true;
        }
    }
}