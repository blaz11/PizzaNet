using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pizza.Net.Domain;
using Pizza.Net.Screens.Pages;
using System.Linq;

namespace Pizza.Net.Tests
{
    [TestClass]
    public class ClientsPageModelShould
    {
        [TestMethod]
        public void AddNewClients()
        {
            var clientsPageModel = new ClientsPageModel();
            clientsPageModel.City = "C";
            clientsPageModel.FirstName = "F";
            clientsPageModel.FlatNumber = "1";
            clientsPageModel.LastName = "L";
            clientsPageModel.PhoneNumber = "P";
            clientsPageModel.PremiseNumber = "1";
            clientsPageModel.Street = "S";
            clientsPageModel.ZipCode = "22-222";
            clientsPageModel.Add();
            using (PizzaNetEntities pne = new PizzaNetEntities())
            {
                var a = pne.Clients.Where(p =>
                (p.City == clientsPageModel.City) &&
                (p.FirstName == clientsPageModel.FirstName) &&
                (p.FlatNumber == clientsPageModel.FlatNumber) &&
                (p.LastName == clientsPageModel.LastName) &&
                (p.PhoneNumber == clientsPageModel.PhoneNumber) &&
                (p.PremiseNumber == clientsPageModel.PremiseNumber) &&
                (p.Street == clientsPageModel.Street) &&
                (p.ZipCode == clientsPageModel.ZipCode)
                );
                Assert.AreNotEqual(a, null);
            }
        }
    }
}
