using Pizza.Net.RestAPIAccess;
using System;
using System.Threading.Tasks;

namespace Pizza.Net.Screens.Pages
{
    class RegisterPageViewModel : ChangingPagesBaseViewModel, IPageViewModel
    {
        public event EventHandler<HarvestPasswordEventArgs> HarvestPassword;
        public event EventHandler<HarvestPasswordEventArgs> HarvestConfirmPassword;

        public async Task Register()
        {
            if (HarvestPassword == null || HarvestConfirmPassword == null)
                return;
            var passwordArgs = new HarvestPasswordEventArgs();
            HarvestPassword(this, passwordArgs);
            var confirmPasswordArgs = new HarvestPasswordEventArgs();
            HarvestConfirmPassword(this, confirmPasswordArgs);
            if(passwordArgs.Password != confirmPasswordArgs.Password)
            {
                Message = ErrorsMessages.PASSWORDS_DONT_MATCH;
                return;
            }
            RegisterResponse result;
            RegisterAccess registerAccess = new RegisterAccess();
            try
            {
                result = await registerAccess.Post(Email, passwordArgs.Password);
            }
            catch (AggregateException)
            {
                Message = ErrorsMessages.CONNECTION_TIMEOUT;
                return;
            }
            if(result != null)
            {
                Message = string.Empty;
                if (result.ModelState.ModelEmail != null)
                    foreach(var item in result.ModelState.ModelEmail)
                    {
                        Message += item + "\n";
                    }
                if (result.ModelState.ModelPassword != null)
                    foreach (var item in result.ModelState.ModelPassword)
                    {
                        Message += item + "\n";
                    }
                if (Message == "")
                    Message = "Email is already registered.";
            }
            else
                Message = "Registration successful.\nYou may now login.";
        }

        public string Email { get; set; }

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

        public string PageName
        {
            get
            {
                return "Register";
            }
        }
    }
}