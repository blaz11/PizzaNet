using System.Collections.ObjectModel;

namespace Pizza.Net.Screens.DesignTimeData
{
    class OrdersTable
    {
        public OrdersTable()
        {
            Orders = new ObservableCollection<OrderEntity>();
            for (int i = 0; i < 15; i++)
            {
                Orders.Add(new OrderEntity());
            }
        }

        public ObservableCollection<OrderEntity> Orders { get; set; }
    }
}