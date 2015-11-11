using Pizza.Net.Domain;

namespace Pizza.Net.Screens.Pages
{
    interface IClientsPageModel
    {
        void SearchClients(Client clientModel);
    }

    class ClientsPageModel : IClientsPageModel
    {
        public void SearchClients(Client clientModel)
        {

        }
    }
}