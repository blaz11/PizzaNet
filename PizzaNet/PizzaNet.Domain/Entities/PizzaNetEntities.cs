using System.Data.Entity;

namespace PizzaNet.Domain.Entities
{
    class PizzaNetEntities : DbContext, IPizzaNetEntities
    {
        static PizzaNetEntities()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<PizzaNetEntities>());
        }
    }
}