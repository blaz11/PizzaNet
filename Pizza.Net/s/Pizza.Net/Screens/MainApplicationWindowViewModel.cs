using Pizza.Net.Screens.Pages;
using Pizza.Net.Screens.Tables;
using Pizza.Net.Screens.Windows;
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
            var clientsPageViewModel = new ClientsPageViewModel(clientsTableViewModel, clientsPageModel);
            var ordersCreatorModel = new OrderCreatorModel();

            // Add available pages
            PageViewModels.Add(clientsPageViewModel);
            PageViewModels.Add(new OrderCreatorViewModel(ordersCreatorModel, clientsPageViewModel));

            // Set starting page
            CurrentPageViewModel = PageViewModels[0];
        }
    }
}