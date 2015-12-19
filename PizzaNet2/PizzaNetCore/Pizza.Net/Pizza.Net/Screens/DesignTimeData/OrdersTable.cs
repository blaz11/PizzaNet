using System.Collections.ObjectModel;

namespace Pizza.Net.Screens.DesignTimeData
{
    class OrdersTable
    {
        public OrdersTable()
        {
            Orders = new ObservableCollection<OrderItem>();
            for (int i = 0; i < 15; i++)
            {
                Orders.Add(new OrderItem());
            }
        }

        public ObservableCollection<OrderItem> Orders { get; set; }
    }
}