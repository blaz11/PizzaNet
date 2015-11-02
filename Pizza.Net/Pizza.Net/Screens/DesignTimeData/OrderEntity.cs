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
                    First_Name = "Dariusz",
                    Last_Name = "Maciejewski"
                };
            }
        }

        public Employee Employee
        {
            get
            {
                return new Employee()
                {
                    First_Name = "Maciej",
                    Last_Name = "Darekszewicz"
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

        public ICollection<Pizza_Order> Pizzas
        {
            get
            {
                var collection = new List<Pizza_Order>();
                var item = new Pizza_Order()
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
