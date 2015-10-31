using PizzaNet.Domain.Entities;
using System;

namespace PizzaNet.Domain.DatabaseAccess
{
    class DbOperationContext : IDisposable
    {
        public DbOperationContext(IPizzaNetDbContext context, PizzaNetEntities entities)
        {
            Context = context;
            Entities = entities;
        }

        public PizzaNetEntities Entities { get; private set; }
        public IPizzaNetDbContext Context { get; private set; }
        public bool RequestRollback { get; set; }
        public bool IsDisposed { get; private set; }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}