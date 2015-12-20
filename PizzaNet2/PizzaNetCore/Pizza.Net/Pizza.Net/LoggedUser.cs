using Pizza.Net.RestAPIAccess;
using PizzaNetCore;

namespace Pizza.Net
{
    class LoggedUser
    {
        public LoggedUser()
        {
        }

        public NotifyTaskCompletion<ClientModel> GetClientModelTaskCompletion { get; set; }

        public void DownloadClientData()
        {
            var clientAccess = new ClientAccess(this);
            GetClientModelTaskCompletion = new NotifyTaskCompletion<ClientModel>(clientAccess.Get());
        }

        public bool TokenValid { get; set; } = false;
        public string Token { get; set; }
    }
}