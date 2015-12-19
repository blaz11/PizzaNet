using Pizza.Net.RestAPIAccess;
using PizzaNetCore;
using System.Threading.Tasks;

namespace Pizza.Net.Screens.Pages
{
    class ClientDataPageModel
    {
        public ClientDataPageModel()
        {
            _downloadedClient = new ClientModel();
            GetData();
        }

        private async Task GetData()
        {
            var clientAccess = new ClientAccess();
            var model = await clientAccess.Get();
            if (CurrentClient == null)
            {
                _downloadedClient.FirstName = model.FirstName;
                _downloadedClient.LastName = model.LastName;
                _downloadedClient.PhoneNumber = model.PhoneNumber;
                _downloadedClient.PremiseNumber = model.PremiseNumber;
                _downloadedClient.Street = model.Street;
                _downloadedClient.ZipCode = model.ZipCode;
                _downloadedClient.FlatNumber = model.FlatNumber;
                _downloadedClient.City = model.City;
                _downloadedClient = model;
            }
            else
            {
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
        }

        private ClientModel _downloadedClient;
        private ClientModel _currentClient;
        public ClientModel CurrentClient
        {
            get
            {
                return _currentClient;
            }
            set
            {
                _currentClient = value;
                if (_currentClient == null)
                    return;
                CurrentClient.FirstName = _downloadedClient.FirstName;
                CurrentClient.LastName = _downloadedClient.LastName;
                CurrentClient.PhoneNumber = _downloadedClient.PhoneNumber;
                CurrentClient.PremiseNumber = _downloadedClient.PremiseNumber;
                CurrentClient.Street = _downloadedClient.Street;
                CurrentClient.ZipCode = _downloadedClient.ZipCode;
                CurrentClient.FlatNumber = _downloadedClient.FlatNumber;
                CurrentClient.City = _downloadedClient.City;
                CurrentClient = _downloadedClient;
            }
        }
    }
}
