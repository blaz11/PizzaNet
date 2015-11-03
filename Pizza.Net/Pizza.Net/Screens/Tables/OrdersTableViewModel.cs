using Pizza.Net.Domain;
using System.Collections.ObjectModel;

namespace Pizza.Net.Screens.Tables
{
    interface IOrdersTableViewModel
    {
        ObservableCollection<Order> Orders { get; set; }
    }

    class OrdersTableViewModel : ObservableObject, IOrdersTableViewModel
    {
        private ObservableCollection<Order> _order;
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
    }
}
