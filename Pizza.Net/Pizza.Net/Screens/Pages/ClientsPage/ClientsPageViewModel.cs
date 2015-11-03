using Pizza.Net.Domain;
using Pizza.Net.Screens.Tables;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Pizza.Net.Screens.Pages
{
    class ClientsPageViewModel : BasePageViewModel, IClientsPageViewModel
    {
        public ClientsPageViewModel(IClientsTableViewModel clientsTableViewModel, IClientsPageModel clientsPageModel, IOrdersTableViewModel ordersTableViewModel)
        {
            ClientsTableViewModel = clientsTableViewModel;
            _clientsPageModel = clientsPageModel;
            _ordersTableViewModel = ordersTableViewModel;
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
                return _firstName;
            }
            set
            {
                if(value != _firstName)
                {
                    _firstName = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _lastName;
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                if (value != _lastName)
                {
                    _lastName = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _city;
        public string City
        {
            get
            {
                return _city;
            }
            set
            {
                if (value != _city)
                {
                    _city = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _zipCode;
        public string ZipCode
        {
            get
            {
                return _zipCode;
            }
            set
            {
                if (value != _zipCode)
                {
                    _zipCode = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _street;
        public string Street
        {
            get
            {
                return _street;
            }
            set
            {
                if (value != _street)
                {
                    _street = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _phoneNumber;
        public string PhoneNumber
        {
            get
            {
                return _phoneNumber;
            }
            set
            {
                if (value != _phoneNumber)
                {
                    _phoneNumber = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _premiseNumber;
        public string PremiseNumber
        {
            get
            {
                return _premiseNumber;
            }
            set
            {
                if (value != _premiseNumber)
                {
                    _premiseNumber = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _flatNumber;
        public string FlatNumber
        {
            get
            {
                return _flatNumber;
            }
            set
            {
                if (value != _flatNumber)
                {
                    _flatNumber = value;
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

        public IClientsTableViewModel ClientsTableViewModel { get; }
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
                //Janek
                var collection = new ObservableCollection<Order>();
                var app = new OrdersHistory();
                var context = new OrdersHistoryViewModel(_ordersTableViewModel, collection);
                app.DataContext = context;
                app.Title = "Orders history for " + client.FirstName + " " + client.LastName;
                app.Show();
            }
        }

        public override void Search()
        {
            //Janek
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
        }

        public override void Add()
        {
            //Janek
            if (SearchMode)
            {
                //Tutaj dodajemy nowy
            }
            else
            {
                //Tutaj edytujemy
                SearchMode = true;
            }
        }

        public override void Edit()
        {
            //Janek
            if (SearchMode)
            {
                if (ClientsTableViewModel.SelectedClient != null)
                {
                    SearchMode = false;
                    var client = ClientsTableViewModel.SelectedClient;
                    FlatNumber = client.FlatNumber;
                    PremiseNumber = client.PremiseNumber;
                    City = client.City;
                    ZipCode = client.ZipCode;
                    LastName = client.LastName;
                    FirstName = client.FirstName;
                    Street = client.Street;
                    PhoneNumber = client.PhoneNumber;
                    //Zapisz gdzies clienta tak zebys mogl pozniej porownac
                }
            }
            else
            {
                SearchMode = true;
            }
        }
    }
}