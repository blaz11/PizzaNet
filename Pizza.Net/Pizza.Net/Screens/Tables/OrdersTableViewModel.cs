using Pizza.Net.Domain;
using System.Collections.ObjectModel;

namespace Pizza.Net.Screens.Tables
{
    interface IOrdersTableViewModel
    {
        ObservableCollection<Order> Orders { get; set; }
        Order SelectedOrder { get; set; }
    }

    class OrdersTableViewModel : ObservableObject, IOrdersTableViewModel
    {
        private ObservableCollection<Order> _order = new ObservableCollection<Order>();
        public ObservableCollection<Order> Orders
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

        private Order _selectedOrder;
        public Order SelectedOrder
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
