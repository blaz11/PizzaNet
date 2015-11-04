using Pizza.Net.Domain;
using System.Collections.ObjectModel;

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
        }

        public string PageName
        {
            get
            {
                return "Submit order";
            }
        }

        public Client Client { get; set; }
        public ObservableCollection<Domain.Pizza> Pizzas { get; set; }

        private void Submit()
        {
            //Janek
        }

    }
}