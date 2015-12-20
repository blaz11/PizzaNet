using Pizza.Net.Screens.Pages;
using Pizza.Net.Screens.Tables;
using Pizza.Net.Screens.Windows;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace Pizza.Net.Screens
{
    class MainApplicationWindowViewModel : CloseableViewModel
    {
        public MainApplicationWindowViewModel(LoggedUser user)
        {
            Username = user.Username;
            InitializeApplication(user);
        }

        private string _username;
        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                if (value == _username)
                    return;
                _username = value;
                OnPropertyChanged();
            }
        }

        private ICommand _changePageCommand;
        public ICommand ChangePageCommand
        {
            get
            {
                if (_changePageCommand == null)
                {
                    _changePageCommand = new RelayCommand(
                        p => ChangeViewModel((IPageViewModel)p),
                        p => p is IPageViewModel);
                }
                return _changePageCommand;
            }
        }

        private ICommand _logoutCommand;
        public ICommand LogoutCommand
        {
            get
            {
                if (_logoutCommand == null)
                {
                    _logoutCommand = new RelayCommand(execute => Logout());
                }
                return _logoutCommand;
            }
        }

        private void Logout()
        {
            var result = MessageBox.Show("Are you sure you want to logout?", "Logout", MessageBoxButton.YesNo);
            switch(result)
            {
                case MessageBoxResult.No:
                case MessageBoxResult.Cancel:
                    return;
            }
            var window = new LoginWindow();
            var context = new LoginWindowViewModel();
            OnClosingRequest();
            window.DataContext = context;
            window.Show();
        }

        private void ChangeViewModel(IPageViewModel viewModel)
        {
            if (!PageViewModels.Contains(viewModel))
                PageViewModels.Add(viewModel);

            CurrentPageViewModel = PageViewModels
                .FirstOrDefault(vm => vm == viewModel);
        }

        private void InitializeApplication(LoggedUser user)
        {
            var ordersTableViewModel = new OrdersTableViewModel();
            var pizzasInOrderCreatorViewModel = new PizzasInOrderCreatorViewModel(new PizzasInOrderCreatorModel(), user);
            var orderSubmitViewModel = new OrderSubmitViewModel(user);
            var clientDataPageModel = new ClientDataPageModel();

            var clientPage = new ClientDataPageViewModel(clientDataPageModel, user);

            // Add available pages
            PageViewModels.Add(clientPage);
            PageViewModels.Add(new OrdersPageViewModel(ordersTableViewModel, user));
            PageViewModels.Add(new OrderCreatorViewModel(pizzasInOrderCreatorViewModel, orderSubmitViewModel));

            // Set starting page
            CurrentPageViewModel = PageViewModels[0];
        }
    }
}