using Pizza.Net.Domain.DatabaseAccess;
using System.Threading.Tasks;
using System.Linq;
using System;
using PizzaNetCore;

namespace PizzaNetWebAPI.DatabaseAccess
{
    static public class ClientsDB
    {
        static public async Task<int> GetClientID(string username)
        {
            var dbACcess = new PizzaNetDbAccess();
            var t = new Func<DbOperationContext, int>((db) =>
            {
                var user = db.Entities.AspNetUsers.Where(p => p.UserName == username);
                if (user.Count() != 1)
                    return -1;
                var userEntity = user.First();
                return userEntity.ClientsAspNetUsers.First().Client.IDClient;
            });
            var result = await dbACcess.ExecuteInTransactionAsync(t);
            return result;
        }

        static public ClientModel GetClientModel(string username)
        {
            var dbACcess = new PizzaNetDbAccess();
            var t = new Func<DbOperationContext, Pizza.Net.Domain.Client>((db) =>
            {
                var d = db as DbOperationContext;
                var cu = d.Entities.ClientsAspNetUsers.Where(p => p.AspNetUser.UserName == username);
                if (cu.Count() != 1)
                    return null;
                return cu.First().Client;
            });
            var result = dbACcess.ExecuteInTransaction(t);
            if (result == null)
                return null;
            var clientModel = new ClientModel();
            clientModel.City = result.City;
            clientModel.FirstName = result.FirstName;
            clientModel.FlatNumber = result.FlatNumber;
            clientModel.LastName = result.LastName;
            clientModel.PhoneNumber = result.PhoneNumber;
            clientModel.PremiseNumber = result.PremiseNumber;
            clientModel.Street = result.Street;
            clientModel.ZipCode = result.ZipCode;
            return clientModel;
        }

        static public void AddClient(string username)
        {
            var dbACcess = new PizzaNetDbAccess();
            dbACcess.ExecuteInTransaction((db) =>
            {
                var user = db.Entities.AspNetUsers.Where(p => p.UserName == username).First();
                var client = new Pizza.Net.Domain.Client();
                client.FirstName = " ";
                client.LastName = " ";
                client.PhoneNumber = " ";
                client.PremiseNumber = " ";
                client.City = " ";
                client.Street = " ";
                client.ZipCode = " ";
                client = db.Entities.Clients.Add(client);
                var clientUser = new Pizza.Net.Domain.ClientsAspNetUser();
                clientUser.AspNetUser = user;
                clientUser.IdAspNetUsers = user.Id;
                clientUser.Client = client;
                clientUser.IDClient = client.IDClient;
                db.Entities.ClientsAspNetUsers.Add(clientUser);
            });
        }
    }
}