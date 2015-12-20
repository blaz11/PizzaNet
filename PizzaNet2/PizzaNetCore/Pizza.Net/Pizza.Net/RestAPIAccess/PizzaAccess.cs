using PizzaNetCore;
using System.Threading.Tasks;

namespace Pizza.Net.RestAPIAccess
{
    class PizzaAccess : WebAccessService
    {
        public async Task<MenuModel> Get()
        {
            var url = "Pizza";
            return await this.Get<MenuModel>(url);
        }
    }
}