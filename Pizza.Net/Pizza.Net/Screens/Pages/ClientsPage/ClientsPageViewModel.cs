﻿using Pizza.Net.Domain;
using Pizza.Net.Screens.Tables;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Linq;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace Pizza.Net.Screens.Pages
{
    class ClientsPageViewModel : BaseTableInteractionViewModel, IClientsPageViewModel, IDataErrorInfo
    {
        private readonly ClientsPageModel currentClient;
        private Dictionary<string, bool> validProperties;
        public ClientsPageViewModel(IClientsTableViewModel clientsTableViewModel, IClientsPageModel clientsPageModel, IOrdersTableViewModel ordersTableViewModel, ClientsPageModel newClient)
        {
            currentClient = newClient;
            validProperties= new Dictionary<string, bool>();
            validProperties.Add("FirstName", false);
            validProperties.Add("LastName", false);
            validProperties.Add("City", false);
            validProperties.Add("ZipCode", false);
            validProperties.Add("Street", false);
            validProperties.Add("PhoneNumber", false);
            validProperties.Add("PremiseNumber", false);
            ClientsTableViewModel = clientsTableViewModel;
            _clientsPageModel = clientsPageModel;
            _ordersTableViewModel = ordersTableViewModel;
            Search();
        }
        #region IDataErrorInfo members

        public string Error
        {
            get { return (currentClient as IDataErrorInfo).Error; }
        }

        public string this[string propertyName]
        {
            get
            {
                string error = (currentClient as IDataErrorInfo)[propertyName];
                validProperties[propertyName] = String.IsNullOrEmpty(error) ? true : false;
                ValidateProperties();
                CommandManager.InvalidateRequerySuggested();
                return error;
            }
        }

        #endregion
        private void ValidateProperties()
        {
            foreach (bool isValid in validProperties.Values)
            {
                if (!isValid)
                {
                    this.AllPropertiesValid = false;
                    return;
                }
            }
            this.AllPropertiesValid = true;
        }
        private bool allPropertiesValid = false;
        public bool AllPropertiesValid
        {
            get { return allPropertiesValid; }
            set
            {
                if (allPropertiesValid != value)
                {
                    allPropertiesValid = value;
                    base.OnPropertyChanged("AllPropertiesValid");
                }
            }
        }
        public string PageName
        {
            get
            {
                return "Clients";
            }
        }

        private string _firstName;
        public string FirstName
        {
            get
            {
                return currentClient.FirstName;
            }
            set
            {
                if(value != currentClient.FirstName)
                {
                    currentClient.FirstName = value;
                    base.OnPropertyChanged();
                }
            }
        }

        private string _lastName;
        public string LastName
        {
            get
            {
                return currentClient.LastName;
            }
            set
            {
                if (value != currentClient.LastName)
                {
                    currentClient.LastName = value;
                    base.OnPropertyChanged();
                }
            }
        }

        private string _city;
        public string City
        {
            get
            {
                return currentClient.City;
            }
            set
            {
                if (value != currentClient.City)
                {
                    currentClient.City = value;
                    base.OnPropertyChanged();
                }
            }
        }

        private string _zipCode;
        public string ZipCode
        {
            get
            {
                return currentClient.ZipCode;
            }
            set
            {
                if (value != currentClient.ZipCode)
                {
                    currentClient.ZipCode = value;
                    base.OnPropertyChanged();
                }
            }
        }

        private string _street;
        public string Street
        {
            get
            {
                return currentClient.Street;
            }
            set
            {
                if (value != currentClient.Street)
                {
                    currentClient.Street = value;
                    base.OnPropertyChanged();
                }
            }
        }

        private string _phoneNumber;
        public string PhoneNumber
        {
            get
            {
                return currentClient.PhoneNumber;
            }
            set
            {
                if (value != currentClient.PhoneNumber)
                {
                    currentClient.PhoneNumber = value;
                    base.OnPropertyChanged();
                }
            }
        }

        private string _premiseNumber;
        public string PremiseNumber
        {
            get
            {
                return currentClient.PremiseNumber;
            }
            set
            {
                if (value != currentClient.PremiseNumber)
                {
                    currentClient.PremiseNumber = value;
                    base.OnPropertyChanged();
                }
            }
        }

        private string _flatNumber;
        public string FlatNumber
        {
            get
            {
                return currentClient.FlatNumber;
            }
            set
            {
                if (value != currentClient.FlatNumber)
                {
                    currentClient.FlatNumber = value;
                    OnPropertyChanged();
                }
            }
        }

        private ICommand _showHistoryCommand;
        public ICommand ShowHistoryCommand
        {
            get
            {
                if (_showHistoryCommand == null)
                {
                    _showHistoryCommand = new RelayCommand(
                        param => ShowHistory());
                }
                return _showHistoryCommand;
            }
        }

        public IClientsTableViewModel ClientsTableViewModel { get; private set; }
        private IClientsPageModel _clientsPageModel;
        private IOrdersTableViewModel _ordersTableViewModel;

        public Client SelectedClient
        {
            get
            {
                return ClientsTableViewModel.SelectedClient;
            }
        }

        private void ShowHistory()
        {
            if (ClientsTableViewModel.SelectedClient != null)
            {
                var client = ClientsTableViewModel.SelectedClient;
                var orders = currentClient.ShowHistory(client);
                if (orders.Count < 1)
                    return;
                    var app = new OrdersHistory();
                var orderEntities = new ObservableCollection<OrderViewModel>();
                foreach(var order in orders)
                {
                    orderEntities.Add(new OrderViewModel(order));
                }
                var context = new OrdersHistoryViewModel(_ordersTableViewModel, orderEntities);
                app.DataContext = context;
                app.Title = "Orders history for " + client.FirstName + " " + client.LastName;
                app.Show();
            }
        }

        public override void Search()
        {
            ClientsTableViewModel=currentClient.SearchClients();

        }
        
        public override void Clear()
        {
            FlatNumber = null;
            PremiseNumber = null;
            City = null;
            ZipCode = null;
            LastName = null;
            FirstName = null;
            Street = null;
            PhoneNumber = null;
            Search();
        }

        public override void Add()
        {
            if (SearchMode)
            {
                using (PizzaNetEntities pne = new PizzaNetEntities())
                {
                    Client cl = new Client();
                    cl.City = _city;
                    cl.FirstName = _firstName;
                    cl.FlatNumber = _flatNumber;
                    cl.LastName = _lastName;
                    cl.PhoneNumber = _phoneNumber;
                    cl.PremiseNumber = _premiseNumber;
                    cl.Street = _street;
                    cl.ZipCode = _zipCode;
                    pne.Clients.Add(cl);
                    pne.SaveChanges();

                }

            }
            else
            {
                using (PizzaNetEntities pne = new PizzaNetEntities())
                {
                    int id = ClientsTableViewModel.SelectedClient.IDClient;
                    var original = pne.Clients.Find(id);

                    if (original != null)
                    {
                        original.City = City;
                        original.FirstName = FirstName;
                        original.FlatNumber = FlatNumber;
                        original.LastName = LastName;
                        original.PhoneNumber = PhoneNumber;
                        original.PremiseNumber = PremiseNumber;
                        original.Street = Street;
                        original.ZipCode = ZipCode;
                        pne.SaveChanges();
                    }
                    SearchMode = true;
                }
            }
            Clear();
        }

        public override void Edit()
        {
            if (SearchMode)
            {
                if (ClientsTableViewModel.SelectedClient != null)
                {
                    SearchMode = false;
                    var client = ClientsTableViewModel.SelectedClient;
                    SetActiveClient(client);
                }
            }
            else
            {
                SearchMode = true;
            }
        }

        public void SetActiveClient(Client client)
        {
            if (client == null)
            {
                Clear();
                return;
            }
            FlatNumber = client.FlatNumber;
            PremiseNumber = client.PremiseNumber;
            City = client.City;
            ZipCode = client.ZipCode;
            LastName = client.LastName;
            FirstName = client.FirstName;
            Street = client.Street;
            PhoneNumber = client.PhoneNumber;
        }
    }
}