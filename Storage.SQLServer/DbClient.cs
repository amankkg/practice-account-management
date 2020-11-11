using BusinessLogic;
using Storage.SQLServer.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Storage.SQLServer
{
    public abstract class DbClient : Client, IClient
    {
        IEnumerable<IAccount> IClient.Accounts
        {
            get => Accounts as IEnumerable<IAccount>;
            set => Accounts = value
                .Select(a => new Account { Id = a.Id, Balance = a.Balance, ClientId = Id })
                .ToList();
        }

        public abstract Task PrintSummary();
    }
}
