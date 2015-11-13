using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pizza.Net.Domain;
using System.ComponentModel;
using Pizza.Net.Screens.Tables;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

namespace Pizza.Net.Screens.Pages
{
    public interface IOrderFinalizationModel
    {
        void FinalizeSelected(int id);
        ObservableCollection<Order> PopulateUnfinishedOrders();
    }
    class OrderFinalizationModel : IOrderFinalizationModel
    {

        public void FinalizeSelected(int id)
        {
            using (PizzaNetEntities pne = new PizzaNetEntities())
            {
                Order o = pne.Orders.Find(id);
                o.FinishOrderDate = new DateTime();
                o.FinishOrderDate = DateTime.Today;
                pne.SaveChanges();
            }
        }
        public ObservableCollection<Order> PopulateUnfinishedOrders()
        {
            ObservableCollection<Order> ord = new ObservableCollection<Order>();
            using (PizzaNetEntities pne = new PizzaNetEntities())
            {
                DateTime myDate = new DateTime();
                var a = pne.Orders.Where(p =>
                DateTime.Compare(p.FinishOrderDate, myDate) <= 0
                );
                ord.Clear();
                foreach (var v in a)
                    ord.Add(v);
            }

            return ord;
        }
    }
}
