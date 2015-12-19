using Pizza.Net.RestAPIAccess;
using PizzaNetCore;
using System.Threading.Tasks;

namespace Pizza.Net.Screens.Pages
{
    class ClientDataPageModel
    {
        public ClientDataPageModel()
        {
            CurrentClient = new ClientModel();
            GetData();
        }

        private async Task GetData()
        {
            var clientAccess = new ClientAccess();
            var model = await clientAccess.Get();
            CurrentClient.FirstName = model.FirstName;
            CurrentClient.LastName = model.LastName;
            CurrentClient.PhoneNumber = model.PhoneNumber;
            CurrentClient.PremiseNumber = model.PremiseNumber;
            CurrentClient.Street = model.Street;
            CurrentClient.ZipCode = model.ZipCode;
            CurrentClient.FlatNumber = model.FlatNumber;
            CurrentClient.City = model.City;
            CurrentClient = model;
        }

        public ClientModel CurrentClient { get; set; }
    }
}
