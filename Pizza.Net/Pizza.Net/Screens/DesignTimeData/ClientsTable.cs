using System.Collections.ObjectModel;

namespace Pizza.Net.Screens.DesignTimeData
{
    class ClientsTable
    {
        public ClientsTable()
        {
            Clients = new ObservableCollection<ClientItem>();
            for(int i = 0; i < 15; i++)
            {
                Clients.Add(new ClientItem());
            }
        }

        public ObservableCollection<ClientItem> Clients { get; set; }
    }
}