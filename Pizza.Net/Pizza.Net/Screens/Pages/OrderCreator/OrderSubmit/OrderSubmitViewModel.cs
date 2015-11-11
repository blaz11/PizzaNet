using Pizza.Net.Domain;
using System.Collections.ObjectModel;
using System;
using System.Globalization;

namespace Pizza.Net.Screens.Pages
{
    interface IOrderSubmitViewModel
    {
        Client Client { get; set; }
        string PageName { get; }
        ObservableCollection<Domain.Pizza> Pizzas { get; set; }
    }

    class OrderSubmitViewModel : ObservableObject, IPageViewModel, IOrderSubmitViewModel
    {
        public OrderSubmitViewModel()
        {
         //   Client = new Client();
       //     Pizzas = new ObservableCollection<Domain.Pizza>();
            System.Console.WriteLine();
        }

        public string PageName
        {
            get
            {
                return "Submit order";
            }
        }

        private Client _client;
        public Client Client
        {
            get
            {
                return _client;
            }
            set
            {
                if (value == _client)
                    return;
                _client = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<Size> _size;
        public ObservableCollection<Size> Sizee
        {
            get
            {
                return _size;
            }
            set
            {
                if (value == _size)
                    return;
                _size = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<Domain.Pizza> _pizzas;
        public ObservableCollection<Domain.Pizza> Pizzas
        {
            get
            {
                return _pizzas;
            }
            set
            {
                if (value == _pizzas)
                    return;
                _pizzas = value;
                OnPropertyChanged();
            }
        }
        public void Submit()
        {
            //Janek
            using (PizzaNetEntities pne = new PizzaNetEntities())
            {

                Order o = new Order();
               
                o.Client = pne.Clients.Find(Client.IDClient);
                o.IDClient = Client.IDClient;
                
                o.StartOrderDate = DateTime.Now;
                pne.Orders.Add(o);
                pne.SaveChanges();
                Console.WriteLine(Sizee);
                int i = 0;
                foreach (var v in Pizzas)
                {
                    //         System.Console.WriteLine(v);
                    pne.PizzaOrders.Add(new PizzaOrder
                    {
                        Pizza = pne.Pizzas.Find(v.IDPizza),
                        Order = pne.Orders.Find(o.IDOrder),
                        Size = pne.Sizes.Find(Sizee[i].IDSize)
                    });
                    i++;
                }
                pne.SaveChanges();
                //         System.Console.WriteLine();

            }
            //     System.Console.WriteLine(Pizzas);
                 System.Console.WriteLine(Client);
        }

    }
}