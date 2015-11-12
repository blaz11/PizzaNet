using Pizza.Net.Domain;
using System.Collections.Generic;

namespace Pizza.Net.Screens.Pages
{
    interface IOrderCreatorModel
    {
        void AddClient(Client client);
        void AddPizza(ICollection<Domain.Pizza> pizzas);
        void SubmitOrder();
    }

    class OrderCreatorModel : IOrderCreatorModel
    {
        private Client _client;
        ICollection<Pizza.Net.Domain.Pizza> _pizzas;

        public void AddClient(Client client)
        {
            _client= client ;
        }

        public void AddPizza(ICollection<Pizza.Net.Domain.Pizza> pizzas)
        {
             _pizzas= pizzas;
        }

        public void SubmitOrder()
        {
            //Janek
            System.Console.WriteLine(    _pizzas);
            System.Console.WriteLine();
        }
    }
}