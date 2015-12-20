using Pizza.Net.RestAPIAccess;
using Pizza.Net.Screens.Tables;
using PizzaNetCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;

namespace Pizza.Net.Screens.Pages
{
    interface IOrderSubmitViewModel : IPageViewModel
    {
        ClientsTableViewModel Client { get; set; }
        PizzasTableViewModel Pizzas { get; set; }
        Task GetClientData();
    }

    class OrderSubmitViewModel : ObservableObject, IOrderSubmitViewModel
    {
        private LoggedUser _user;

        public OrderSubmitViewModel(LoggedUser user)
        {
            _user = user;
            GetClientData();
            ProgressBarVisibility = false;
        }

        public async Task GetClientData()
        {
            var client = await _user.GetClientModelTaskCompletion.Task;
            Client.Clients.Clear();
            Client.Clients.Add(client);
        }

        public string PageName
        {
            get
            {
                return "Submit order";
            }
        }

        public ClientsTableViewModel Client { get; set; } = new ClientsTableViewModel();

        public ObservableCollection<SizeModel> Sizes { get; set; } = new ObservableCollection<SizeModel>();

        public PizzasTableViewModel Pizzas { get; set; } = new PizzasTableViewModel();

        public async Task Submit()
        {
            var orderModel = new OrderModel();
            orderModel.StartOrderDate = DateTime.Now;
            var list = new List<PizzaInOrderModel>();

            int i = 0;
            foreach(var item in Pizzas.Pizzas)
            {
                var model = new PizzaInOrderModel();
                model.PizzaModel = item;
                model.SizeModel = Sizes[i];
                i++;
                list.Add(model);
            }
            orderModel.Pizzas = list;
            var oa = new OrderAccess(_user);
            ProgressBarVisibility = true;
            ProgressBarText = "Sending your order...";
            await oa.Post(orderModel);
            ProgressBarVisibility = false;
            MessageBox.Show("Order submitted successfuly. Email confirmation has been sent.");
        }

        private bool _progressBarVisibility = true;
        public bool ProgressBarVisibility
        {
            get
            {
                return _progressBarVisibility;
            }
            set
            {
                if (value != _progressBarVisibility)
                {
                    _progressBarVisibility = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _progressBarText;
        public string ProgressBarText
        {
            get
            {
                return _progressBarText;
            }
            set
            {
                if (value == _progressBarText)
                    return;
                _progressBarText = value;
                OnPropertyChanged();
            }
        }
    }
}