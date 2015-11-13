using Pizza.Net.Screens.Tables;
using System.Windows.Input;
using Pizza.Net.Domain;
using System.Linq;
using System;

namespace Pizza.Net.Screens.Pages
{
    interface IOrderFinalizatorViewModel
    {
        ICommand FinalizeCommand { get; }
        string PageName { get; }
        IOrdersTableViewModel UnfinishedOrders { get; }
    }

    class OrderFinalizatorViewModel : ObservableObject, IPageViewModel, IOrderFinalizatorViewModel
    {
        private readonly OrderFinalizationModel _currentFinalizator;
        public OrderFinalizatorViewModel(OrderFinalizationModel newOrderFinalizator)
        {
            _currentFinalizator = newOrderFinalizator;
            UnfinishedOrders = new OrdersTableViewModel();
            PopulateUnfinishedOrders();
        }

        public string PageName
        {
            get
            {
                return "Finalize Order";
            }
        }

        public IOrdersTableViewModel UnfinishedOrders { get; private set; }

        private ICommand _finalizeCommand;
        public ICommand FinalizeCommand
        {
            get
            {
                if (_finalizeCommand == null)
                {
                    _finalizeCommand = new RelayCommand(
                        param => FinalizeSelected());
                }
                return _finalizeCommand;
            }
        }

        private ICommand _refreshCommand;
        public ICommand RefreshCommand
        {
            get
            {
                if (_refreshCommand == null)
                {
                    _refreshCommand = new RelayCommand(
                        param => PopulateUnfinishedOrders());
                }
                return _refreshCommand;
            }
        }

        private void FinalizeSelected()
        {
            var orderToFinalize = UnfinishedOrders.SelectedOrder;
            if (orderToFinalize == null)
                return;
            _currentFinalizator.FinalizeSelected(orderToFinalize.Order.IDOrder);
            PopulateUnfinishedOrders();
        }

        private void PopulateUnfinishedOrders()
        {
            UnfinishedOrders.Orders.Clear();
            foreach (var v in _currentFinalizator.PopulateUnfinishedOrders())
                UnfinishedOrders.Orders.Add(new OrderViewModel(v));
        }
    }
}