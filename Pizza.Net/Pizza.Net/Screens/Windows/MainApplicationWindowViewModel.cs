using Pizza.Net.Screens.Pages;
using Pizza.Net.Screens.Tables;
using System.Linq;
using System.Windows.Input;

namespace Pizza.Net.Screens
{
    class MainApplicationWindowViewModel : ChangingPagesBaseViewModel
    {
        public MainApplicationWindowViewModel()
        {
            InitializeApplication();
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

        private void InitializeApplication()
        {
            var clientsTableViewModel = new ClientsTableViewModel();
            var clientsPageModel = new ClientsPageModel();
            var ordersTableViewModel = new OrdersTableViewModel();
            var clientPageModel = new ClientsPageModel();
            var clientsPageViewModel = new ClientsPageViewModel(clientsTableViewModel, clientsPageModel, ordersTableViewModel, clientPageModel);
            var ordersCreatorModel = new OrderCreatorModel();
            var pizzasTableViewModel = new PizzasTableViewModel();
            var pizzasPageViewModel = new PizzasPageViewModel(pizzasTableViewModel, new PizzasPageModel());
            var pizzasInOrderCreatorViewModel = new PizzasInOrderCreatorViewModel(new PizzasInOrderCreatorModel());

            // Add available pages
            PageViewModels.Add(clientsPageViewModel);
            PageViewModels.Add(pizzasPageViewModel);
            PageViewModels.Add(new OrdersPageViewModel(new OrdersPageModel()));
            PageViewModels.Add(new OrderCreatorViewModel(ordersCreatorModel, clientsPageViewModel, pizzasInOrderCreatorViewModel));
            PageViewModels.Add(new OrderFinalizatorViewModel(new OrderFinalizationModel()));

            // Set starting page
            CurrentPageViewModel = PageViewModels[0];
        }
    }
}