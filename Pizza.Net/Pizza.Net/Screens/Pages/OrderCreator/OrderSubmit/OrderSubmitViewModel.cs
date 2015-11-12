using Pizza.Net.Domain;
using System.Collections.ObjectModel;
using System;
using Pizza.Net.Screens.Tables;
using System.Linq;

namespace Pizza.Net.Screens.Pages
{
    interface IOrderSubmitViewModel : IPageViewModel
    {
        ClientsTableViewModel Client { get; set; }
        PizzasTableViewModel Pizzas { get; set; }
    }

    class OrderSubmitViewModel : ObservableObject, IOrderSubmitViewModel
    {
        public string PageName
        {
            get
            {
                return "Submit order";
            }
        }

        public ClientsTableViewModel Client { get; set; } = new ClientsTableViewModel();

        public ObservableCollection<Size> Sizes { get; set; } = new ObservableCollection<Size>();

        public PizzasTableViewModel Pizzas { get; set; } = new PizzasTableViewModel();

        public void Submit()
        {
            using (PizzaNetEntities pne = new PizzaNetEntities())
            {
                Order o = new Order();
                var client = Client.Clients.First();
                o.Client = pne.Clients.Find(client.IDClient);
                o.IDClient = client.IDClient;
                o.StartOrderDate = DateTime.Now;
                pne.Orders.Add(o);
                pne.SaveChanges();
                int i = 0;
                foreach (var v in Pizzas.Pizzas)
                {
                    pne.PizzaOrders.Add(new PizzaOrder
                    {
                        Pizza = pne.Pizzas.Find(v.Pizza.IDPizza),
                        Order = pne.Orders.Find(o.IDOrder),
                        Size = pne.Sizes.Find(Sizes[i].IDSize)
                    });
                    i++;
                }
                pne.SaveChanges();
            }
        }
    }
}