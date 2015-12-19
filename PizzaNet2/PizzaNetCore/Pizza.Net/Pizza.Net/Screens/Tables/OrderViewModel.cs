using PizzaNetCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Pizza.Net.Screens.Tables
{
    class OrderViewModel : ObservableObject
    {
        public OrderViewModel(OrderModel order)
        {
            Pizzas = new ObservableCollection<string>();
            int sum= 0;
            //using (PizzaNetEntities pne = new PizzaNetEntities())
            //{
            //    var c= pne.Clients.Find(order.IDClient);
            //    Client = c.FirstName + " " + c.LastName;

            //    var pi = pne.PizzaOrders.Where(p => p.IDOrder == order.IDOrder);
            //    foreach(var v in pi)
            //    {
            //        Pizzas.Add(pne.Pizzas.Find(v.IDPizza).Name);
            //        sum += (int)pne.Pizzas.Find(v.IDPizza).Price * v.Size.BasePriceMultiplier;
            //    }
            //}
            OrderValue = sum;
            DateTime myDatetime = new DateTime(1800, 1, 1);
            StartDate = order.StartOrderDate.ToString();
            if (DateTime.Compare(order.FinishOrderDate, myDatetime) <= 0)
                FinishDate = "Not finished";
            else
                FinishDate = order.FinishOrderDate.ToString();
            Order = order;
        }

        private ObservableCollection<string> ConvertFromPizzaOrderCollectionToStringCollection(ICollection<PizzaInOrderModel> pizzaOrder)
        {
            var converted = new ObservableCollection<string>();
            foreach (var item in pizzaOrder)
            {
                string v = item.PizzaModel.Name + " " + item.SizeModel.Name + " " + item.PizzaModel.Price * item.SizeModel.PriceMultiplier;
                converted.Add(v);
            }
            return converted;
        }

        public OrderModel Order { get; private set; }

        private string _client;
        public string Client
        {
            get
            {
                return _client;
            }
            set
            {
                if(value != _client)
                {
                    _client = value;
                    OnPropertyChanged();
                }
            }
        }

        private ObservableCollection<string> _pizzas;
        public ObservableCollection<string> Pizzas
        {
            get
            {
                return _pizzas;
            }
            set
            {
                if (value != _pizzas)
                {
                    _pizzas = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _startDate;
        public string StartDate
        {
            get
            {
                return _startDate;
            }
            set
            {
                if (value != _startDate)
                {
                    _startDate = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _finishDate;
        public string FinishDate
        {
            get
            {
                return _finishDate;
            }
            set
            {
                if (value != _finishDate)
                {
                    _finishDate = value;
                    OnPropertyChanged();
                }
            }
        }

        private double _orderValue;
        public double OrderValue
        {
            get
            {
                return _orderValue;
            }
            set
            {
                if (value != _orderValue)
                {
                    _orderValue = value;
                    OnPropertyChanged();
                }
            }
        }

    }
}