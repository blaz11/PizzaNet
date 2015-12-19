using Pizza.Net.Screens.Pages;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Pizza.Net.Screens.Windows
{
    class LoginWindowViewModel : CloseableViewModel
    {
        public LoginWindowViewModel()
        {
            var loginPageViewModel = new LoginPageViewModel();
            var registerPageViewModel = new RegisterPageViewModel();
            PageViewModels.Add(loginPageViewModel);
            PageViewModels.Add(registerPageViewModel);
            CurrentPageViewModel = loginPageViewModel;
        }
        
        private ICommand _changeToLoginScreen;
        public ICommand ChangeToLoginScreen
        {
            get
            {
                if (_changeToLoginScreen == null)
                {
                    _changeToLoginScreen = new RelayCommand(
                        execute => ChangeViewModel(PageViewModels[0]));
                }
                return _changeToLoginScreen;
            }
        }

        private ICommand _changeToRegisterScreen;
        public ICommand ChangeToRegisterScreen
        {
            get
            {
                if (_changeToRegisterScreen == null)
                {
                    _changeToRegisterScreen = new RelayCommand(
                        execute => ChangeViewModel(PageViewModels[1]));
                }
                return _changeToRegisterScreen;
            }
        }

        private void ChangeViewModel(IPageViewModel viewModel)
        {
            if (CurrentPageViewModel == viewModel)
            {
                if (viewModel == PageViewModels[0])
                    HandleLogin();
                else if (viewModel == PageViewModels[1])
                    HandleRegister();
                return;
            }
            if (!PageViewModels.Contains(viewModel))
                PageViewModels.Add(viewModel);
            CurrentPageViewModel = PageViewModels
                .FirstOrDefault(vm => vm == viewModel);
        }

        private async void HandleRegister()
        {
            await (PageViewModels[1] as RegisterPageViewModel).Register();
        }

        private async void HandleLogin()
        {
            if (await Task.Run(() => (PageViewModels[0] as LoginPageViewModel).Login()))
                LoginSuccesful();
        }

        private void LoginSuccesful()
        {
            var app = new MainApplicationWindow();
            var context = new MainApplicationWindowViewModel();
            OnClosingRequest();
            app.DataContext = context;
            app.Title = "Pizza.Net";
            app.Show();
        }
    }
}