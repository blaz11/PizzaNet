using Pizza.Net.Screens.Windows;
using PizzaNetCore;
using System.Windows.Input;

namespace Pizza.Net.Screens.Pages
{
    class ClientDataPageViewModel : ObservableObject, IPageViewModel
    {
        private ClientDataPageModel _model;

        public ClientDataPageViewModel(ClientDataPageModel model)
        {
            _model = model;
            _currentClient = new ClientModel();
        }

        private ICommand _okButtonClickCommand;
        public ICommand OkButtonClickCommand
        {
            get
            {
                if (_okButtonClickCommand == null)
                {
                    _okButtonClickCommand = new RelayCommand(
                        param => AcceptChanges());
                }
                return _okButtonClickCommand;
            }
        }

        private ICommand _cancelButtonClickCommand;
        public ICommand CancelButtonClickCommand
        {
            get
            {
                if (_cancelButtonClickCommand == null)
                {
                    _cancelButtonClickCommand = new RelayCommand(
                        param => CancelChanges());
                }
                return _cancelButtonClickCommand;
            }
        }

        private ICommand _changePasswordButtonClickCommand;
        public ICommand ChangePasswordButtonClickCommand
        {
            get
            {
                if (_changePasswordButtonClickCommand == null)
                {
                    _changePasswordButtonClickCommand = new RelayCommand(
                        param => ChangePaassword());
                }
                return _changePasswordButtonClickCommand;
            }
        }

        private readonly ClientModel _currentClient;

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

        public string PageName
        {
            get
            {
                return "Your info";
            }
        }

        private void AcceptChanges()
        {

        }

        private void CancelChanges()
        {

        }

        private ChangePasswordWindow _changePasswordWindow;

        private void ChangePaassword()
        {
            if (_changePasswordWindow != null)
                _changePasswordWindow.Close();
            _changePasswordWindow = new ChangePasswordWindow();
            var context = new ChangePasswordWindowViewModel();
            _changePasswordWindow.DataContext = context;
            _changePasswordWindow.Show();
        }
    }
}