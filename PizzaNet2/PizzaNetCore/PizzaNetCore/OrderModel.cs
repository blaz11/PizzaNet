using System;
using System.Collections.Generic;

namespace PizzaNetCore
{
    public class ClientOrdersModel
    {
        public IEnumerable<OrderModel> Orders { get; set; }
    }

    public class OrderModel
    {
        public IEnumerable<PizzaInOrderModel> Pizzas { get; set; }
        public DateTime StartOrderDate { get; set; } 
        public DateTime FinishOrderDate { get; set; }
    }

    public class PizzaInOrderModel
    {
        public PizzaModel PizzaModel { get; set; }
        public SizeModel SizeModel { get; set; }
    }

    public class SizeModel
    {
        public string Name { get; set; }
        public double Radius { get; set; }
        public double PriceMultiplier { get; set; }
    }
}