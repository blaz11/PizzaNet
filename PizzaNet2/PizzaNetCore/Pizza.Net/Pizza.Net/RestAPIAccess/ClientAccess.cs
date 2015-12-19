using PizzaNetCore;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Pizza.Net.RestAPIAccess
{
    class ClientAccess : WebAccessService
    {
        public ClientAccess()
        {
            this._httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", UserSingleton.Token);
        }

        public async Task<ClientModel> Get()
        {
            var url = "Client";
            return await this.Get<ClientModel>(url);
        }
    }
}
