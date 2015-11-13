using Pizza.Net.Domain;
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
        private readonly OrdersPageModel _currentOrdersPageModel;
        public IOrdersTableViewModel UnfinishedOrders { get; private set; }
        public OrdersPageViewModel(OrdersPageModel newOrdersPageModel)
        {
            _currentOrdersPageModel = newOrdersPageModel;
            UnfinishedOrders = new OrdersTableViewModel();
           // ToDate = DateTime.Now;
        }

        public string PageName
        {
            get
            {
                return "Orders";
            }
        }

        public string FirstName
        {
            get
            {
                return _currentOrdersPageModel.FirstName;
            }
            set
            {
                if (value != _currentOrdersPageModel.FirstName)
                {
                    _currentOrdersPageModel.FirstName = value;
                    OnPropertyChanged();
                }
            }
        }

        public string LastName
        {
            get
            {
                return _currentOrdersPageModel.LastName;
            }
            set
            {
                if (value != _currentOrdersPageModel.LastName)
                {
                    _currentOrdersPageModel.LastName = value;
                    OnPropertyChanged();
                }
            }
        }

        public DateTime? ToDate
        {
            get
            {
                return _currentOrdersPageModel.ToDate;
            }
            set
            {
                if (value != _currentOrdersPageModel.ToDate)
                {
                    _currentOrdersPageModel.ToDate = value;
                    OnPropertyChanged();
                }
            }
        }

        public DateTime? FromDate
        {
            get
            {
                return _currentOrdersPageModel.FromDate;
            }
            set
            {
                if (value != _currentOrdersPageModel.FromDate)
                {
                    _currentOrdersPageModel.FromDate = value;
                    OnPropertyChanged();
                }
            }
        }

        public uint? FromValue
        {
            get
            {
                return _currentOrdersPageModel.FromValue;
            }
            set
            {
                if (value != _currentOrdersPageModel.FromValue)
                {
                    _currentOrdersPageModel.FromValue = value;
                    OnPropertyChanged();
                }
            }
        }

        public uint? ToValue
        {
            get
            {
                return _currentOrdersPageModel.ToValue;
            }
            set
            {
                if (value != _currentOrdersPageModel.ToValue)
                {
                    _currentOrdersPageModel.ToValue = value;
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

            UnfinishedOrders.Orders.Clear();
            foreach(var v in _currentOrdersPageModel.Search())
                UnfinishedOrders.Orders.Add(new OrderViewModel(v));
        }

        private void Clear()
        {
            ToValue = null;
            FirstName = null;
            LastName = null;
            FromValue = null;
            ToDate = null;
            FromDate = null;
            Search();
        }
    }
}