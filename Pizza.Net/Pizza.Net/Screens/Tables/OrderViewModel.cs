﻿using Pizza.Net.Domain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Pizza.Net.Screens.Tables
{
    class OrderViewModel : ObservableObject
    {
        public OrderViewModel(Order order)
        {
            Pizzas = new ObservableCollection<string>();
            decimal suma = 0;
            using (PizzaNetEntities pne = new PizzaNetEntities())
            {
                var c= pne.Clients.Find(order.IDClient);
                Client = c.FirstName + " " + c.LastName;

                var pi = pne.PizzaOrders.Where(p => p.IDOrder == order.IDOrder);
                foreach(var v in pi)
                {
                    Pizzas.Add(pne.Pizzas.Find(v.IDPizza).Name);
                    suma += pne.Pizzas.Find(v.IDPizza).Price;
                }
            }

            //   Client = order.Client.FirstName + " " + order.Client.LastName;
            //       Pizzas = ConvertFromPizzaOrderCollectionToStringCollection(order.PizzaOrders);
            //OrderValue = CalculateTotalOrderValue(order.PizzaOrders);
            OrderValue = (double)suma;
            DateTime myDatetime = new DateTime();
            StartDate = order.StartOrderDate;
            if (DateTime.Compare(order.FinishOrderDate, myDatetime) <= 0)
                FinishDate = "otwarte";
            else
                FinishDate = order.FinishOrderDate.ToLongDateString();
            Order = order;
        }

        private ObservableCollection<string> ConvertFromPizzaOrderCollectionToStringCollection(ICollection<PizzaOrder> pizzaOrder)
        {
            var converted = new ObservableCollection<string>();
            foreach (var item in pizzaOrder)
            {
                string v = item.Pizza.Name + " " + item.Size.Name + " " + item.Pizza.Price * item.Size.BasePriceMultiplier;
                converted.Add(v);
            }
            return converted;
        }

        private double CalculateTotalOrderValue(ICollection<PizzaOrder> pizzaOrder)
        {
            double result = 0;
            foreach(var item in pizzaOrder)
            {
                result += (double)(item.Pizza.Price * item.Size.BasePriceMultiplier);
            }
            return result;
        }

        public Order Order { get; private set; }

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

        private DateTime _startDate;
        public DateTime StartDate
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