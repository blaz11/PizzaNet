using Pizza.Net.Screens.Windows;
using PizzaNetCore;
using System.Windows.Input;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using Pizza.Net.RestAPIAccess;
using System.Threading.Tasks;
using System.Windows;

namespace Pizza.Net.Screens.Pages
{
    class ClientDataPageViewModel : ObservableObject, IPageViewModel, IDataErrorInfo
    {
        private ClientDataPageModel _model;

        public bool _editVisible = false;
        public bool EditVisible
        {
            get
            {
                return _editVisible;
            }
            set
            {
                _editVisible = value;
                base.OnPropertyChanged();
            }
        }

        public bool _viewVisible = true;
        public bool ViewVisible
        {
            get
            {
                return _viewVisible;
            }
            set
            {
                _viewVisible = value;
                base.OnPropertyChanged();
            }
        }

        private LoggedUser _user;

        public ClientDataPageViewModel(ClientDataPageModel model, LoggedUser user)
        {
            _model = model;
            _user = user;
            _validProperties = new Dictionary<string, bool>();
            _validProperties.Add("FirstName", false);
            _validProperties.Add("LastName", false);
            _validProperties.Add("City", false);
            _validProperties.Add("ZipCode", false);
            _validProperties.Add("Street", false);
            _validProperties.Add("PhoneNumber", false);
            _validProperties.Add("PremiseNumber", false);
            ProgressBarText = "Getting your data...";
            GetClientData();
        }

        private async Task GetClientData()
        {
            _downloadedClient =  await _user.GetClientModelTaskCompletion.Task;
            FirstName = _downloadedClient.FirstName;
            LastName = _downloadedClient.LastName;
            City = _downloadedClient.City;
            ZipCode = _downloadedClient.ZipCode;
            Street = _downloadedClient.Street;
            PhoneNumber = _downloadedClient.PhoneNumber;
            FlatNumber = _downloadedClient.FlatNumber;
            PremiseNumber = _downloadedClient.PremiseNumber;
            ProgressBarVisibility = false;
            ViewVisible = !ViewVisible;
            EditVisible = !EditVisible;
        }

        private ClientModel _downloadedClient;

        private bool _allPropertiesValid = false;
        public bool AllPropertiesValid
        {
            get { return _allPropertiesValid; }
            set
            {
                if (_allPropertiesValid != value)
                {
                    _allPropertiesValid = value;
                    base.OnPropertyChanged("AllPropertiesValid");
                }
            }
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

        public string FirstName
        {
            get
            {
                return _model.FirstName;
            }
            set
            {
                if (value != _model.FirstName)
                {
                    _model.FirstName = value;
                    base.OnPropertyChanged();
                }
            }
        }


        public string LastName
        {
            get
            {
                return _model.LastName;
            }
            set
            {
                if (value != _model.LastName)
                {
                    _model.LastName = value;
                    base.OnPropertyChanged();
                }
            }
        }

        public string City
        {
            get
            {
                return _model.City;
            }
            set
            {
                if (value != _model.City)
                {
                    _model.City = value;
                    base.OnPropertyChanged();
                }
            }
        }

        public string ZipCode
        {
            get
            {
                return _model.ZipCode;
            }
            set
            {
                if (value != _model.ZipCode)
                {
                    _model.ZipCode = value;
                    base.OnPropertyChanged();
                }
            }
        }

        public string Street
        {
            get
            {
                return _model.Street;
            }
            set
            {
                if (value != _model.Street)
                {
                    _model.Street = value;
                    base.OnPropertyChanged();
                }
            }
        }

        public string PhoneNumber
        {
            get
            {
                return _model.PhoneNumber;
            }
            set
            {
                if (value != _model.PhoneNumber)
                {
                    _model.PhoneNumber = value;
                    base.OnPropertyChanged();
                }
            }
        }

        public string PremiseNumber
        {
            get
            {
                return _model.PremiseNumber;
            }
            set
            {
                if (value != _model.PremiseNumber)
                {
                    _model.PremiseNumber = value;
                    base.OnPropertyChanged();
                }
            }
        }


        public string FlatNumber
        {
            get
            {
                return _model.FlatNumber;
            }
            set
            {
                if (value != _model.FlatNumber)
                {
                    _model.FlatNumber = value;
                    OnPropertyChanged();
                }
            }
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
                if(value != _progressBarVisibility)
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

        public string PageName
        {
            get
            {
                return "Your info";
            }
        }


        private async Task AcceptChanges()
        {
            if(!AllPropertiesValid)
            {
                MessageBox.Show("Fill in required fields!");
            }
            _downloadedClient.FirstName = FirstName;
            _downloadedClient.LastName = LastName;
            _downloadedClient.City = City;
            _downloadedClient.ZipCode = ZipCode;
            _downloadedClient.Street = Street;
            _downloadedClient.PhoneNumber = PhoneNumber;
            _downloadedClient.FlatNumber = FlatNumber;
            _downloadedClient.PremiseNumber = PremiseNumber;
            var ac = new ClientAccess(_user);
            ProgressBarText = "Sending your request...";
            ProgressBarVisibility = true;
            await ac.Post(_downloadedClient);
            ProgressBarVisibility = false;
            MessageBox.Show("Your info has beed updated");
            _user.DownloadClientData();
        }

        private void CancelChanges()
        {
            FirstName = _downloadedClient.FirstName;
            LastName = _downloadedClient.LastName;
            City = _downloadedClient.City;
            ZipCode = _downloadedClient.ZipCode;
            Street = _downloadedClient.Street;
            PhoneNumber = _downloadedClient.PhoneNumber;
            FlatNumber = _downloadedClient.FlatNumber;
            PremiseNumber = _downloadedClient.PremiseNumber;
        }

        private ChangePasswordWindow _changePasswordWindow;

        private void ChangePaassword()
        {
            if (_changePasswordWindow != null)
                _changePasswordWindow.Close();
            _changePasswordWindow = new ChangePasswordWindow();
            var context = new ChangePasswordWindowViewModel(_user);
            _changePasswordWindow.DataContext = context;
            _changePasswordWindow.Show();
        }
    }
}