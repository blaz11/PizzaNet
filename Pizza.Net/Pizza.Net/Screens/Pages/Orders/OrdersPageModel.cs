using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pizza.Net.Domain;
using Pizza.Net.Screens.Tables;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Windows.Input;

namespace Pizza.Net.Screens.Pages
{
    public interface IOrdersPageModel
    {
        ObservableCollection<Order> Search();
    }
    public class OrdersPageModel : IOrdersPageModel
    {
        public uint? ToValue { get; set; }
        public uint? FromValue { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }

        public ObservableCollection<Order> Search()
        {
            ObservableCollection<Order> ord = new ObservableCollection<Order>();
            using (PizzaNetEntities pne = new PizzaNetEntities())
            {
                Console.WriteLine(FromDate);
                Console.WriteLine(ToDate);
                var a = pne.Orders.Where(p =>
                (FromDate == null || DateTime.Compare(p.StartOrderDate, FromDate.Value) >= 0) &&
                (ToDate == null || DateTime.Compare(p.StartOrderDate, ToDate.Value) < 0) &&
                (FirstName == null || FirstName == "" || String.Compare(p.Client.FirstName, FirstName) == 0) &&
                (LastName == null || LastName == "" || String.Compare(p.Client.LastName, LastName) == 0)
                );
                ord.Clear();
                foreach (var v in a)
                {
                    int sum = 0;
                    var pi = pne.PizzaOrders.Where(p => p.IDOrder == v.IDOrder);
                    foreach (var v1 in pi)
                    {
                        sum += (int)pne.Pizzas.Find(v1.IDPizza).Price * v1.Size.BasePriceMultiplier;
                    }
                    if ((!ToValue.HasValue || sum < ToValue.Value) && (!FromValue.HasValue || sum > FromValue.Value))
                       ord.Add(v);
                }

            }
            return ord;
        }
    }
}
