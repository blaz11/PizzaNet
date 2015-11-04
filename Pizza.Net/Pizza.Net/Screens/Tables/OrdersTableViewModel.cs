using System.Collections.ObjectModel;

namespace Pizza.Net.Screens.Tables
{
    interface IOrdersTableViewModel
    {
        ObservableCollection<OrderViewModel> Orders { get; set; }
        OrderViewModel SelectedOrder { get; set; }
    }

    class OrdersTableViewModel : ObservableObject, IOrdersTableViewModel
    {
        private ObservableCollection<OrderViewModel> _order = new ObservableCollection<OrderViewModel>();
        public ObservableCollection<OrderViewModel> Orders
        {
            get
            {
                return _order;
            }
            set
            {
                if (value != _order)
                {
                    _order = value;
                    OnPropertyChanged();
                }
            }
        }

        private OrderViewModel _selectedOrder;
        public OrderViewModel SelectedOrder
        {
            get
            {
                return _selectedOrder;
            }
            set
            {
                if (value != _selectedOrder)
                {
                    _selectedOrder = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
