using PizzaNetCore;
using System;
using System.Collections.Generic;

namespace Pizza.Net.Screens.DesignTimeData
{
    class OrderItem
    {
        public ClientModel Client
        {
            get
            {
                return new ClientModel()
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

        public ICollection<PizzaInOrderModel> Pizzas
        {
            get
            {
                var collection = new List<PizzaInOrderModel>();
                var item = new PizzaInOrderModel()
                {
                    PizzaModel = new PizzaModel()
                    {
                        Name = "Wegetariańska",
                        Price = 30
                    },
                    SizeModel = new SizeModel()
                    {
                        Name = "Średnia",
                        PriceMultiplier = 20.0,
                        Radius = 15.0
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