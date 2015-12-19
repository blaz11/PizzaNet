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
            var ordersTableViewModel = new OrdersTableViewModel();
            var pizzasTableViewModel = new PizzasTableViewModel();
            var pizzasInOrderCreatorViewModel = new PizzasInOrderCreatorViewModel(new PizzasInOrderCreatorModel());

            var clientDataPageModel = new ClientDataPageModel();
            var clientPage = new ClientDataPageViewModel(clientDataPageModel);

            // Add available pages
            PageViewModels.Add(clientPage);
            PageViewModels.Add(new OrdersPageViewModel(new OrdersPageModel()));
            PageViewModels.Add(new OrderCreatorViewModel(pizzasInOrderCreatorViewModel));

            // Set starting page
            CurrentPageViewModel = PageViewModels[0];
        }
    }
}