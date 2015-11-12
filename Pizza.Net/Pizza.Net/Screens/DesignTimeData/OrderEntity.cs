using Pizza.Net.Domain;
using System;
using System.Collections.Generic;

namespace Pizza.Net.Screens.DesignTimeData
{
    class OrderEntity
    {
        public Client Client
        {
            get
            {
                return new Client()
                {
                    FirstName = "Dariusz",
                    LastName = "Maciejewski"
                };
            }
        }

        public DateTime StartDate
        {
            get
            {
                return new DateTime(2015, 9, 2, 13, 32, 0);
            }
        }

        public DateTime FinishDate
        {
            get
            {
                return new DateTime(2015, 9, 2, 14, 32, 0);
            }
        }

        public ICollection<PizzaOrder> Pizzas
        {
            get
            {
                var collection = new List<PizzaOrder>();
                var item = new PizzaOrder()
                {
                    Pizza = new Pizza.Net.Domain.Pizza()
                    {
                        Name = "Wegetariańska",
                        Price = 30
                    },
                    Size = new Size()
                    {
                        Name = "Średnia"
                    },

                };
                for(int i = 0; i < 5; i++)
                {
                    collection.Add(item);
                }
                return collection;
            }
        }
    }
}
