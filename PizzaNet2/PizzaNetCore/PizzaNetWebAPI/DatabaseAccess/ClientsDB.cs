using Pizza.Net.Domain.DatabaseAccess;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace PizzaNetWebAPI.DatabaseAccess
{
    static public class ClientsDB
    {
        static public async Task<string> GetClientID(string username)
        {
            var dbACcess = new PizzaNetDbAccess();
            var t = new Func<DbOperationContext, string>((db) =>
            {
                var user = db.Entities.AspNetUsers.Where(p => p.UserName == username);
                if (user.Count() != 1)
                    return null;
                var userEntity = user.First();
                return userEntity.ClientsAspNetUsers.First().Client.IDClient.ToString();
            });
            var result = await dbACcess.ExecuteInTransactionAsync(t);
            return result;
        }
    }
}