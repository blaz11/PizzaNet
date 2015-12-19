using Pizza.Net.RestAPIAccess;
using System;

namespace Pizza.Net.Screens.Pages
{
    class HarvestPasswordEventArgs : EventArgs
    {
        public string Password;
    }

    class LoginPageViewModel : ChangingPagesBaseViewModel, IPageViewModel
    {
        public event EventHandler<HarvestPasswordEventArgs> HarvestPassword;

        public bool Login()
        {
            if (HarvestPassword == null)
                return false;
            var passwordArgs = new HarvestPasswordEventArgs();
            HarvestPassword(this, passwordArgs);
            TokenProvider.TokenRequestResult token = null;
            try
            {
                token = TokenProvider.GetToken(Email, passwordArgs.Password);
            }
            catch(AggregateException)
            {
                ErrorMessage = ErrorsMessages.CONNECTION_TIMEOUT;
                return false;
            }
            if (token.AccessToken != null)
            {
                UserSingleton.Email = Email;
                UserSingleton.TokenValid = true;
                UserSingleton.Token = token.AccessToken;
                ErrorMessage = null;
                return true;
            }
            ErrorMessage = token.ErrorDescription;
            return false;
        }

        public string Email { get; set; }

        private string _errorMessage;
        public string ErrorMessage
        {
            get
            {
                return _errorMessage;
            }
            set
            {
                if (value != _errorMessage)
                {
                    _errorMessage = value;
                    OnPropertyChanged();
                }
            }
        }

        public string PageName
        {
            get
            {
                return "Login";
            }
        }
    }
}
