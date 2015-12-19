using Pizza.Net.Screens.Windows;
using PizzaNetCore;
using System.Windows.Input;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Pizza.Net.Screens.Pages
{
    class ClientDataPageViewModel : ObservableObject, IPageViewModel, IDataErrorInfo
    {
        private ClientDataPageModel _model;
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

        public ClientDataPageViewModel(ClientDataPageModel model)
        {
            _model = model;
            _validProperties = new Dictionary<string, bool>();
            _validProperties.Add("FirstName", false);
            _validProperties.Add("LastName", false);
            _validProperties.Add("City", false);
            _validProperties.Add("ZipCode", false);
            _validProperties.Add("Street", false);
            _validProperties.Add("FlatNumber", false);
            _validProperties.Add("PhoneNumber", false);
            _validProperties.Add("PremiseNumber", false);
            _currentClient = new ClientModel();
        }
        public string Error
        {
            get { return (_model as IDataErrorInfo).Error; }
        }

        public string this[string propertyName]
        {
            get
            {
                string error = (_model as IDataErrorInfo)[propertyName];
                _validProperties[propertyName] = String.IsNullOrEmpty(error) ? true : false;
                ValidateProperties();
                CommandManager.InvalidateRequerySuggested();
                return error;
            }
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
            System.Console.WriteLine();
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