using Pizza.Net.RestAPIAccess;
using Pizza.Net.Screens.Tables;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Pizza.Net.Screens.Pages
{
    interface IOrdersPageViewModel : IPageViewModel
    {
        ICommand GetOrdersCommand { get; }
    }

    class OrdersPageViewModel : ObservableObject, IOrdersPageViewModel
    {
        private LoggedUser _user;
        public OrdersPageViewModel(OrdersTableViewModel tableViewModel, LoggedUser user)
        {
            _user = user;
            OrdersTable = tableViewModel;
            GetOrders();
        }

        public OrdersTableViewModel OrdersTable { get; set; }

        public string PageName
        {
            get
            {
                return "Your orders history";
            }
        }

        private ICommand _getOrdersCommand;
        public ICommand GetOrdersCommand
        {
            get
            {
                if (_getOrdersCommand == null)
                {
                    _getOrdersCommand = new RelayCommand(
                        param => GetOrders());
                }
                return _getOrdersCommand;
            }
        }

        private bool _progressBarVisibility = true;
        public bool ProgressBarVisibility
        {
            get
            {
                return _progressBarVisibility;
            }
            set
            {
                if (value != _progressBarVisibility)
                {
                    _progressBarVisibility = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _progressBarText;
        public string ProgressBarText
        {
            get
            {
                return _progressBarText;
            }
            set
            {
                if (value == _progressBarText)
                    return;
                _progressBarText = value;
                OnPropertyChanged();
            }
        }

        private async Task GetOrders()
        {
            ProgressBarText = "Getting your orders history...";
            ProgressBarVisibility = true;
            var orderAccess = new OrderAccess(_user);
            var result = await orderAccess.Get();
            if (result.Orders != null)
            {
                OrdersTable.Orders.Clear();
                foreach (var item in result.Orders)
                {
                    OrdersTable.Orders.Add(new OrderViewModel(item));
                }
            }
            ProgressBarVisibility = false;
        }
    }
}