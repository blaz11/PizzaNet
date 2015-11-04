using Pizza.Net.Screens.Tables;
using System.Windows.Input;

namespace Pizza.Net.Screens.Pages
{
    interface IOrderFinalizatorViewModel
    {
        ICommand FinalizeCommand { get; }
        string PageName { get; }
        IOrdersTableViewModel UnfinishedOrders { get; }
    }

    class OrderFinalizatorViewModel : ObservableObject, IPageViewModel, IOrderFinalizatorViewModel
    {
        public OrderFinalizatorViewModel()
        {
            PopulateUnfinishedOrders();
        }

        public string PageName
        {
            get
            {
                return "Finalize Order";
            }
        }

        public IOrdersTableViewModel UnfinishedOrders { get; private set; }

        private ICommand _finalizeCommand;
        public ICommand FinalizeCommand
        {
            get
            {
                if (_finalizeCommand == null)
                {
                    _finalizeCommand = new RelayCommand(
                        param => FinalizeSelected());
                }
                return _finalizeCommand;
            }
        }

        private void FinalizeSelected()
        {
            var orderToFinalize = UnfinishedOrders.SelectedOrder;
            //Janek 
            PopulateUnfinishedOrders();
        }

        private void PopulateUnfinishedOrders()
        {
            //Janek
        }
    }
}