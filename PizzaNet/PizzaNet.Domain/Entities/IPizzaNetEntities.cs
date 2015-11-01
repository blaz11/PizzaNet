using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaNet.Domain.Entities
{
    interface IPizzaNetEntities : IDisposable
    {
        int SaveChanges();
    }
}
