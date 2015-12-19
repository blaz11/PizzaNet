using Pizza.Net.Screens.Tables;
using System.Collections.ObjectModel;

namespace Pizza.Net.Screens
{
    interface IOrdersHistoryViewModel
    {
        IOrdersTableViewModel OrdersTableViewModel { get; set; }
    }

    class OrdersHistoryViewModel : IOrdersHistoryViewModel
    {
        public OrdersHistoryViewModel(IOrdersTableViewModel ordersTableViewModel, ObservableCollection<OrderViewModel> orders)
        {
            OrdersTableViewModel = ordersTableViewModel;
            OrdersTableViewModel.Orders = orders;
        }

        public IOrdersTableViewModel OrdersTableViewModel { get; set; }
    }
}