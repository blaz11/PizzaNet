using PizzaNetCore;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Pizza.Net.RestAPIAccess
{
    class ClientAccess : TokenAuthenticatedWebServiceAccess
    {
        public ClientAccess(LoggedUser user): base(user)
        {
        }

        public async Task<ClientModel> Get()
        {
            var url = "Client";
            return await this.Get<ClientModel>(url);
        }

        public async Task<string> Post(ClientModel model)
        {
            var url = "Client";
            return await this.Post<ClientModel, string>(url, model);
        }
    }
}
