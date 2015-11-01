using System.Collections.ObjectModel;

namespace Pizza.Net.Screens.DesignTimeData
{
    class ClientsTable
    {
        public ClientsTable()
        {
            Clients = new ObservableCollection<ClientEntity>();
            for(int i = 0; i < 15; i++)
            {
                Clients.Add(new ClientEntity());
            }
        }

        public ObservableCollection<ClientEntity> Clients { get; set; }
    }
}