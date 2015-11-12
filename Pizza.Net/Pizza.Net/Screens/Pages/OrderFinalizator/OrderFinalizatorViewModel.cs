using Pizza.Net.Screens.Tables;
using System.Windows.Input;
using Pizza.Net.Domain;
using System.Linq;
using System;

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
            UnfinishedOrders = new OrdersTableViewModel();
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

        private ICommand _refreshCommand;
        public ICommand RefreshCommand
        {
            get
            {
                if (_refreshCommand == null)
                {
                    _refreshCommand = new RelayCommand(
                        param => PopulateUnfinishedOrders());
                }
                return _refreshCommand;
            }
        }

        private void FinalizeSelected()
        {
            var orderToFinalize = UnfinishedOrders.SelectedOrder;
            if (orderToFinalize == null)
                return;
            using (PizzaNetEntities pne = new PizzaNetEntities())
            {
                Order o = pne.Orders.Find(orderToFinalize.Order.IDOrder);
                o.FinishOrderDate= new DateTime();
                o.FinishOrderDate = DateTime.Today;
                pne.SaveChanges();
            }
            PopulateUnfinishedOrders();
        }

        private void PopulateUnfinishedOrders()
        {
            using (PizzaNetEntities pne = new PizzaNetEntities())
            {
                DateTime myDate = new DateTime();
                var a = pne.Orders.Where(p =>
                DateTime.Compare(p.FinishOrderDate, myDate)<=0
                );
                UnfinishedOrders.Orders.Clear();
                foreach (var v in a)
                    UnfinishedOrders.Orders.Add(new OrderViewModel(v));
            }
        }
    }
}