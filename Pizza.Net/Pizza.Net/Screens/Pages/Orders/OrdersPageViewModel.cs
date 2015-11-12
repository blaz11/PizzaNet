﻿using Pizza.Net.Domain;
using Pizza.Net.Screens.Tables;
using System;
using System.Linq;
using System.Windows.Input;

namespace Pizza.Net.Screens.Pages
{
    interface IOrdersPageViewModel : IPageViewModel
    {
        ICommand AddToSelectedCommand { get; }
        ICommand ClearCommand { get; }
        string FirstName { get; set; }
        DateTime? FromDate { get; set; }
        uint? FromValue { get; set; }
        string LastName { get; set; }
        IPizzasTableViewModel PizzasToSelectViewModel { get; }
        ICommand RemoveFromSelectedCommand { get; }
        ICommand SearchCommand { get; }
        IPizzasTableViewModel SelectedPizzasViewModel { get; }
        DateTime? ToDate { get; set; }
        uint? ToValue { get; set; }
        IOrdersTableViewModel UnfinishedOrders { get; }
    }

    class OrdersPageViewModel : ObservableObject, IOrdersPageViewModel
    {
        public IOrdersTableViewModel UnfinishedOrders { get; private set; }
        public OrdersPageViewModel()
        {
            UnfinishedOrders = new OrdersTableViewModel();
        }

        public string PageName
        {
            get
            {
                return "Orders";
            }
        }

        private string _firstName;
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                if (value != _firstName)
                {
                    _firstName = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _lastName;
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                if (value != _lastName)
                {
                    _lastName = value;
                    OnPropertyChanged();
                }
            }
        }

        private DateTime? _toDate;
        public DateTime? ToDate
        {
            get
            {
                return _toDate;
            }
            set
            {
                if (value != _toDate)
                {
                    _toDate = value;
                    OnPropertyChanged();
                }
            }
        }

        private DateTime? _fromDate;
        public DateTime? FromDate
        {
            get
            {
                return _fromDate;
            }
            set
            {
                if (value != _fromDate)
                {
                    _fromDate = value;
                    OnPropertyChanged();
                }
            }
        }

        private uint? _fromValue;
        public uint? FromValue
        {
            get
            {
                return _fromValue;
            }
            set
            {
                if (value != _fromValue)
                {
                    _fromValue = value;
                    OnPropertyChanged();
                }
            }
        }

        private uint? _toValue;
        public uint? ToValue
        {
            get
            {
                return _toValue;
            }
            set
            {
                if (value != _toValue)
                {
                    _toValue = value;
                    OnPropertyChanged();
                }
            }
        }

        public IPizzasTableViewModel PizzasToSelectViewModel { get; private set; }
        public IPizzasTableViewModel SelectedPizzasViewModel { get; private set; }

        private ICommand _searchCommand;
        public ICommand SearchCommand
        {
            get
            {
                if (_searchCommand == null)
                {
                    _searchCommand = new RelayCommand(
                        param => Search());
                }
                return _searchCommand;
            }
        }

        private ICommand _clearCommand;
        public ICommand ClearCommand
        {
            get
            {
                if (_clearCommand == null)
                {
                    _clearCommand = new RelayCommand(
                        param => Clear());
                }
                return _clearCommand;
            }
        }

        private ICommand _addToSelectedCommand;
        public ICommand AddToSelectedCommand
        {
            get
            {
                if (_addToSelectedCommand == null)
                {
                    _addToSelectedCommand = new RelayCommand(
                        param => Search());
                }
                return _addToSelectedCommand;
            }
        }

        private ICommand _removeFromSelectedCommand;
        public ICommand RemoveFromSelectedCommand
        {
            get
            {
                if (_removeFromSelectedCommand == null)
                {
                    _removeFromSelectedCommand = new RelayCommand(
                        param => RemoveFromSelected());
                }
                return _removeFromSelectedCommand;
            }
        }

        private void AddToSelected()
        {
            //       var item = PizzasToSelectViewModel.SelectedPizza;
            //       if (item == null)
            //            return;
            //        PizzasToSelectViewModel.Pizzas.Remove(item);
            //       SelectedPizzasViewModel.Pizzas.Add(item);
        }

        private void RemoveFromSelected()
        {
            //       var item = PizzasToSelectViewModel.SelectedPizza;
            //       if (item == null)
            //           return;
            //      SelectedPizzasViewModel.Pizzas.Add(item);
            //       PizzasToSelectViewModel.Pizzas.Remove(item);
        }

        private void Search()
        {
            using (PizzaNetEntities pne = new PizzaNetEntities())
            {
                Console.WriteLine(FromDate);
                Console.WriteLine(ToDate);
                var a = pne.Orders.Where(p =>
                (FromDate == null || DateTime.Compare(p.StartOrderDate, FromDate.Value) >= 0) &&
                (ToDate == null || DateTime.Compare(p.StartOrderDate, ToDate.Value) <= 0) &&
                (FirstName == null || FirstName == "" || String.Compare(p.Client.FirstName, FirstName) == 0) &&
                (LastName == null || LastName == "" || String.Compare(p.Client.LastName, LastName) == 0)
                );
                UnfinishedOrders.Orders.Clear();
                foreach (var v in a)
                {
                    int sum = 0;
                    var pi = pne.PizzaOrders.Where(p => p.IDOrder == v.IDOrder);
                    foreach (var v1 in pi)
                    {
                        sum += (int)pne.Pizzas.Find(v1.IDPizza).Price * v1.Size.BasePriceMultiplier;
                    }
                    if((!ToValue.HasValue || sum<ToValue.Value) && (!FromValue.HasValue || sum>FromValue.Value))
                        UnfinishedOrders.Orders.Add(new OrderViewModel(v));
                }
                    
            }
        }

        private void Clear()
        {
            ToValue = null;
            FromValue = null;
            ToDate = DateTime.Now;
            FromDate = DateTime.Now;
            Search();
        }
    }
}