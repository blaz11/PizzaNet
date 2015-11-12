using Pizza.Net.Domain;
using Pizza.Net.Screens.Tables;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System;
using System.ComponentModel;
using System.Collections.Generic;

namespace Pizza.Net.Screens.Pages
{
    class ClientsPageViewModel : BaseTableInteractionViewModel, IClientsPageViewModel, IDataErrorInfo
    {
        public ClientsPageViewModel(IClientsTableViewModel clientsTableViewModel, IClientsPageModel clientsPageModel, IOrdersTableViewModel ordersTableViewModel, ClientsPageModel newClient)
        {
            _currentClient = newClient;
            _validProperties = new Dictionary<string, bool>();
            _validProperties.Add("FirstName", false);
            _validProperties.Add("LastName", false);
            _validProperties.Add("City", false);
            _validProperties.Add("ZipCode", false);
            _validProperties.Add("Street", false);
            _validProperties.Add("PhoneNumber", false);
            _validProperties.Add("PremiseNumber", false);
            ClientsTableViewModel = clientsTableViewModel;
            _clientsPageModel = clientsPageModel;
            _ordersTableViewModel = ordersTableViewModel;
            Search();
        }

        #region IDataErrorInfo members

        public string Error
        {
            get { return (_currentClient as IDataErrorInfo).Error; }
        }

        public string this[string propertyName]
        {
            get
            {
                string error = (_currentClient as IDataErrorInfo)[propertyName];
                _validProperties[propertyName] = String.IsNullOrEmpty(error) ? true : false;
                ValidateProperties();
                CommandManager.InvalidateRequerySuggested();
                return error;
            }
        }

        #endregion

        private readonly ClientsPageModel _currentClient;

        private Dictionary<string, bool> _validProperties;

        private void ValidateProperties()
        {
            foreach (bool isValid in _validProperties.Values)
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


        public string FirstName
        {
            get
            {
                return _currentClient.FirstName;
            }
            set
            {
                if (value != _currentClient.FirstName)
                {
                    _currentClient.FirstName = value;
                    base.OnPropertyChanged();
                }
            }
        }


        public string LastName
        {
            get
            {
                return _currentClient.LastName;
            }
            set
            {
                if (value != _currentClient.LastName)
                {
                    _currentClient.LastName = value;
                    base.OnPropertyChanged();
                }
            }
        }


        public string City
        {
            get
            {
                return _currentClient.City;
            }
            set
            {
                if (value != _currentClient.City)
                {
                    _currentClient.City = value;
                    base.OnPropertyChanged();
                }
            }
        }

        public string ZipCode
        {
            get
            {
                return _currentClient.ZipCode;
            }
            set
            {
                if (value != _currentClient.ZipCode)
                {
                    _currentClient.ZipCode = value;
                    base.OnPropertyChanged();
                }
            }
        }

        public string Street
        {
            get
            {
                return _currentClient.Street;
            }
            set
            {
                if (value != _currentClient.Street)
                {
                    _currentClient.Street = value;
                    base.OnPropertyChanged();
                }
            }
        }

        public string PhoneNumber
        {
            get
            {
                return _currentClient.PhoneNumber;
            }
            set
            {
                if (value != _currentClient.PhoneNumber)
                {
                    _currentClient.PhoneNumber = value;
                    base.OnPropertyChanged();
                }
            }
        }

        public string PremiseNumber
        {
            get
            {
                return _currentClient.PremiseNumber;
            }
            set
            {
                if (value != _currentClient.PremiseNumber)
                {
                    _currentClient.PremiseNumber = value;
                    base.OnPropertyChanged();
                }
            }
        }

        public string FlatNumber
        {
            get
            {
                return _currentClient.FlatNumber;
            }
            set
            {
                if (value != _currentClient.FlatNumber)
                {
                    _currentClient.FlatNumber = value;
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
                var orders = _currentClient.ShowHistory(client);
                if (orders.Count < 1)
                    return;
                var app = new OrdersHistory();
                var orderEntities = new ObservableCollection<OrderViewModel>();
                foreach (var order in orders)
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
            ClientsTableViewModel.Clients.Clear();
            foreach (var v in _currentClient.SearchClients().Clients)
                ClientsTableViewModel.Clients.Add(v);
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

        private int _editedClientID;

        public override void Add()
        {
            if (SearchMode)
            {
                _currentClient.Add();
            }
            else
            {
                _currentClient.Edit(_editedClientID);
                SearchMode = true;
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
                    _editedClientID = client.IDClient;
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