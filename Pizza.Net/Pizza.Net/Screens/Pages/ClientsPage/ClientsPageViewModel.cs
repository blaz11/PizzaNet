using Pizza.Net.Domain;
using Pizza.Net.Screens.Tables;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Linq;
using System.Data.Entity;

namespace Pizza.Net.Screens.Pages
{
    class ClientsPageViewModel : BaseTableInteractionViewModel, IClientsPageViewModel
    {
        public ClientsPageViewModel(IClientsTableViewModel clientsTableViewModel, IClientsPageModel clientsPageModel, IOrdersTableViewModel ordersTableViewModel)
        {
            ClientsTableViewModel = clientsTableViewModel;
            _clientsPageModel = clientsPageModel;
            _ordersTableViewModel = ordersTableViewModel;
            Search();
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
                //Janek
                var orders = new ObservableCollection<Order>();
                using (PizzaNetEntities pne = new PizzaNetEntities())
                {
                    var a = pne.Orders.Where(p => p.Client.IDClient == client.IDClient);
                    foreach (var v in a)
                        orders.Add(v);
                }
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
            //Janek
            using (PizzaNetEntities pne = new PizzaNetEntities())
            {
                var a = pne.Clients.Where(p =>
                (p.City == City || City == "" || City==null)&&
                (p.FirstName == FirstName || FirstName == "" || FirstName == null) &&
                (p.FlatNumber == FlatNumber || FlatNumber == "" || FlatNumber == null) &&
                (p.LastName == LastName || LastName == "" || LastName == null) &&
                (p.PhoneNumber == PhoneNumber || PhoneNumber == "" || PhoneNumber == null) &&
                (p.PremiseNumber == PremiseNumber || PremiseNumber == "" || PremiseNumber == null) &&
                (p.Street == Street || Street == "" || Street == null) &&
                (p.ZipCode == ZipCode || ZipCode == "" || ZipCode == null)
                );
                //     System.Console.WriteLine(a);
                ClientsTableViewModel.Clients.Clear();
                foreach (var v in a)
                    ClientsTableViewModel.Clients.Add(v);
            }
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
            //Janek




            if (SearchMode)
            {
                //Tutaj dodajemy nowy
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
                //Tutaj edytujemy
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