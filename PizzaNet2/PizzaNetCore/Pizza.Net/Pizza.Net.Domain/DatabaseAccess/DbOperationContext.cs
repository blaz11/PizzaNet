using System;

namespace Pizza.Net.Domain.DatabaseAccess
{
    public class DbOperationContext : IDisposable
    {
        public DbOperationContext(PizzaNetEntities entities)
        {
            Entities = entities;
        }

        public PizzaNetEntities Entities { get; private set; }
        public bool RequestRollback { get; set; }
        public bool IsDisposed { get; private set; }

        public void Dispose()
        {
            IsDisposed = true;
        }
    }
}