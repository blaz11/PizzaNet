using PizzaNetCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Pizza.Net.Screens.Tables
{
    class OrderViewModel : ObservableObject
    {
        public OrderViewModel(OrderModel order)
        {
            Pizzas = new ObservableCollection<PizzaInOrderModel>(order.Pizzas);
            double sum = 0;
            foreach(var item in order.Pizzas)
            {
                sum += item.PizzaModel.Price * item.SizeModel.PriceMultiplier;
            }
            OrderValue = sum;
            DateTime myDatetime = new DateTime(1800, 1, 1);
            StartDate = order.StartOrderDate.ToString();
            if (DateTime.Compare(order.FinishOrderDate, myDatetime) <= 0)
                FinishDate = "Not finished";
            else
                FinishDate = order.FinishOrderDate.ToString();
            Order = order;
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

        private ObservableCollection<PizzaInOrderModel> _pizzas;
        public ObservableCollection<PizzaInOrderModel> Pizzas
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