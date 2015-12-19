using PizzaNetCore;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace Pizza.Net.Screens.Pages
{
    public interface IOrdersPageModel
    {
        ObservableCollection<OrderModel> Search();
    }

    public class OrdersPageModel : IOrdersPageModel
    {
        public uint? ToValue { get; set; }
        public uint? FromValue { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }

        public ObservableCollection<OrderModel> Search()
        {
            ObservableCollection<OrderModel> ord = new ObservableCollection<OrderModel>();
            //using (PizzaNetEntities pne = new PizzaNetEntities())
            //{
            //    var a = pne.Orders.Where(p =>
            //    (FromDate == null || DateTime.Compare(p.StartOrderDate, FromDate.Value) >= 0) &&
            //    (ToDate == null || DateTime.Compare(p.StartOrderDate, ToDate.Value) < 0) &&
            //    (FirstName == null || FirstName == "" || String.Compare(p.Client.FirstName, FirstName) == 0) &&
            //    (LastName == null || LastName == "" || String.Compare(p.Client.LastName, LastName) == 0)
            //    );
            //    ord.Clear();
            //    foreach (var v in a)
            //    {
            //        int sum = 0;
            //        var pi = pne.PizzaOrders.Where(p => p.IDOrder == v.IDOrder);
            //        foreach (var v1 in pi)
            //        {
            //            sum += (int)pne.Pizzas.Find(v1.IDPizza).Price * v1.Size.BasePriceMultiplier;
            //        }
            //        if ((!ToValue.HasValue || sum < ToValue.Value) && (!FromValue.HasValue || sum > FromValue.Value))
            //            ord.Add(v);
            //    }
            //}
            return ord;
        }
    }
}
