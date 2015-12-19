using Pizza.Net.RestAPIAccess;
using Pizza.Net.Screens.Pages;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Pizza.Net.Screens.Windows
{
    class ChangePasswordWindowViewModel : CloseableViewModel
    {
        public event EventHandler<HarvestPasswordEventArgs> HarvestOldPassword;

        public event EventHandler<HarvestPasswordEventArgs> HarvestNewPassword;

        public event EventHandler<HarvestPasswordEventArgs> HarvestNewPasswordConfirm;

        private ICommand _cancelButtonCommand;
        public ICommand CancelButtonCommand
        {
            get
            {
                if (_cancelButtonCommand == null)
                {
                    _cancelButtonCommand = new RelayCommand(
                        param => CancelPasswordChange());
                }
                return _cancelButtonCommand;
            }
        }

        private ICommand _okButtonCommand;
        public ICommand OkButtonCommand
        {
            get
            {
                if (_okButtonCommand == null)
                {
                    _okButtonCommand = new RelayCommand(
                        param => ConfirmPasswordChange());
                }
                return _okButtonCommand;
            }
        }

        private async Task ConfirmPasswordChange()
        {
            if (HarvestNewPassword == null || HarvestNewPasswordConfirm == null || HarvestOldPassword == null)
                return;
            var newPassowrdArgs = new HarvestPasswordEventArgs();
            HarvestNewPassword(this, newPassowrdArgs);
            var confirmNewPassowrdArgs = new HarvestPasswordEventArgs();
            HarvestNewPasswordConfirm(this, confirmNewPassowrdArgs);
            var oldPasswordArgs = new HarvestPasswordEventArgs();
            HarvestOldPassword(this, oldPasswordArgs);
            if(newPassowrdArgs.Password != confirmNewPassowrdArgs.Password)
            {
                Message = ErrorsMessages.PASSWORDS_DONT_MATCH;
                return;
            }
            ChangePasswordResponse result;
            var changePasswordAccess = new ChangePasswordAccess();
            try
            {
                result = await changePasswordAccess.Post(oldPasswordArgs.Password, newPassowrdArgs.Password);

            }
            catch (AggregateException)
            {
                Message = ErrorsMessages.CONNECTION_TIMEOUT;
                return;
            }
            if(result != null)
            {
                Message = string.Empty;
                if (result.ModelState.ModelNewPassword != null)
                {
                    foreach (var item in result.ModelState.ModelNewPassword)
                    {
                        Message += item + '\n';
                    }
                }
                if(Message == string.Empty)
                {
                    Message += "Password is incorrect.";
                }
                return;
            }
            Message = "Password changed successfuly.";
        }

        private void CancelPasswordChange()
        {
            OnClosingRequest();
        }

        private string _message;
        public string Message
        {
            get
            {
                return _message;
            }
            set
            {
                if (value != _message)
                {
                    _message = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}