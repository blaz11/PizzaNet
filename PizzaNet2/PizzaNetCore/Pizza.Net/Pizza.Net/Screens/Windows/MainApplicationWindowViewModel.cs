using Pizza.Net.Screens.Pages;
using Pizza.Net.Screens.Tables;
using System.Linq;
using System.Windows.Input;

namespace Pizza.Net.Screens
{
    class MainApplicationWindowViewModel : ChangingPagesBaseViewModel
    {
        public MainApplicationWindowViewModel(LoggedUser user)
        {
            InitializeApplication(user);
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