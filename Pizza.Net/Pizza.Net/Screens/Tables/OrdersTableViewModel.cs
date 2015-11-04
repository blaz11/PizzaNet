using Pizza.Net.Domain;
using Pizza.Net.Screens.Entities;
using System.Collections.ObjectModel;

namespace Pizza.Net.Screens.Tables
{
    interface IOrdersTableViewModel
    {
        ObservableCollection<OrderEntityViewModel> Orders { get; set; }
        OrderEntityViewModel SelectedOrder { get; set; }
    }

    class OrdersTableViewModel : ObservableObject, IOrdersTableViewModel
    {
        private ObservableCollection<OrderEntityViewModel> _order = new ObservableCollection<OrderEntityViewModel>();
        public ObservableCollection<OrderEntityViewModel> Orders
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

        private OrderEntityViewModel _selectedOrder;
        public OrderEntityViewModel SelectedOrder
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
