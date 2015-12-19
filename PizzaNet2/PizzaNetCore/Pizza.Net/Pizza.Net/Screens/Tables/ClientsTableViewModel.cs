using PizzaNetCore;
using System.Collections.ObjectModel;

namespace Pizza.Net.Screens.Tables
{
    public interface IClientsTableViewModel
    {
        ObservableCollection<ClientModel> Clients { get; set; }
        ClientModel SelectedClient { get; set; }
    }

    public class ClientsTableViewModel : ObservableObject, IClientsTableViewModel
    {
        public ClientsTableViewModel()
        {
        }

        private ObservableCollection<ClientModel> _clients = new ObservableCollection<ClientModel>();
        public ObservableCollection<ClientModel> Clients
        {
            get
            {
                return _clients;
            }
            set
            {
                if (value != _clients)
                {
                    _clients = value;
                    OnPropertyChanged();
                }
            }
        }

        private ClientModel _selectedClient;
        public ClientModel SelectedClient
        {
            get
            {
                return _selectedClient;
            }
            set
            {
                if (value != _selectedClient)
                {
                    _selectedClient = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}