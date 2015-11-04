using Pizza.Net.Screens.Entities;
using Pizza.Net.Screens.Tables;
using System.Collections.ObjectModel;

namespace Pizza.Net.Screens
{
    interface IOrdersHistoryViewModel
    {
        IOrdersTableViewModel OrdersTableViewModel { get; }
    }

    class OrdersHistoryViewModel : IOrdersHistoryViewModel
    {
        public OrdersHistoryViewModel(IOrdersTableViewModel ordersTableViewModel, ObservableCollection<OrderEntityViewModel> orders)
        {
            OrdersTableViewModel = ordersTableViewModel;
            OrdersTableViewModel.Orders = orders;
        }

        public IOrdersTableViewModel OrdersTableViewModel { get; }
    }
}