using Pizza.Net.Screens.Tables;
using System.Windows.Input;
using Pizza.Net.Domain;
using System.Collections.ObjectModel;
using System.Linq;
using System.Data.Entity;
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

        private void FinalizeSelected()
        {
            var orderToFinalize = UnfinishedOrders.SelectedOrder;
            //Janek 
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
            //Janek
            using (PizzaNetEntities pne = new PizzaNetEntities())
            {
                DateTime myDate = new DateTime();
                var a = pne.Orders.Where(p =>
                DateTime.Compare(p.FinishOrderDate, myDate)<=0
                );
                //     System.Console.WriteLine(a);
                UnfinishedOrders.Orders.Clear();
                foreach (var v in a)
                    UnfinishedOrders.Orders.Add(new OrderViewModel(v));
            }
        }
    }
}