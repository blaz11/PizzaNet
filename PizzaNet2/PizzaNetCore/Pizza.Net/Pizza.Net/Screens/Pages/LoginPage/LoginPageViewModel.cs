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

        public LoggedUser Login()
        {
            if (HarvestPassword == null)
                return null;
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
                return null;
            }
            if (token.AccessToken != null)
            {
                var user = new LoggedUser();
                user.TokenValid = true;
                user.Token = token.AccessToken;
                user.Username = Email;
                user.DownloadClientData();
                return user;
            }
            ErrorMessage = token.ErrorDescription;
            return null;
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
