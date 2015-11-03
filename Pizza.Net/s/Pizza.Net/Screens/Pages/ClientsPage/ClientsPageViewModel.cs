using Pizza.Net.Domain;
using Pizza.Net.Screens.Tables;
using System.Windows.Input;

namespace Pizza.Net.Screens.Pages
{
    class ClientsPageViewModel : ObservableObject, IClientsPageViewModel
    {
        public ClientsPageViewModel(IClientsTableViewModel clientsTableViewModel, IClientsPageModel clientsPageModel)
        {
            _clientsTableViewModel = clientsTableViewModel;
            _clientsPageModel = clientsPageModel;
        }

        public string Name
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

        private uint? _premiseNumber;
        public uint? PremiseNumber
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

        private uint? _flatNumber;
        public uint? FlatNumber
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

        private IClientsTableViewModel _clientsTableViewModel;
        private IClientsPageModel _clientsPageModel;

        public Client SelectedClient
        {
            get
            {
                return _clientsTableViewModel.SelectedClient;
            }
        }

        private ICommand _searchClientsCommand;
        public ICommand SearchClientsCommand
        {
            get
            {
                if(_searchClientsCommand == null)
                {
                    _searchClientsCommand = new RelayCommand(
                        param => SearchProducts());
                }
                return _searchClientsCommand;
            }
        }

        private ICommand _clearCommand;
        public ICommand ClearCommand
        {
            get
            {
                if (_clearCommand == null)
                {
                    _clearCommand = new RelayCommand(
                        param => ClearSearchFields());
                }
                return _clearCommand;
            }
        }

        private ICommand _addNewClientCommand;
        public ICommand AddNewClientCommand
        {
            get
            {
                if (_addNewClientCommand == null)
                {
                    _addNewClientCommand = new RelayCommand(
                        param => AddNewClient());
                }
                return _addNewClientCommand;
            }
        }

        private ICommand _editClientCommand;
        public ICommand EditClientCommand
        {
            get
            {
                if (_editClientCommand == null)
                {
                    _editClientCommand = new RelayCommand(
                        param => EditCurrentlySelectedClient());
                }
                return _editClientCommand;
            }
        }

        private void SearchProducts()
        {
            //Janek
        }

        private void ClearSearchFields()
        {
            //bkula
        }

        private void AddNewClient()
        {
            //bkula
        }

        private void EditCurrentlySelectedClient()
        {
            //bkula
        }
    }
}