using PizzaNet.Domain.Entities;
using System;

namespace PizzaNet.Domain.DatabaseAccess
{
    class DbTransaction : IDisposable
    {
        public DbTransaction(IPizzaNetDbContext context, IPizzaNetDbEntities entities)
        {
            Context = context;
            Entities = entities;
        }

        public IPizzaNetDbEntities Entities { get; private set; }
        public IPizzaNetDbContext Context { get; private set; }
        public bool RequestRollback { get; set; }
        public bool IsDisposed { get; private set; }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}