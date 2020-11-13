using BusinessLogic;
using Storage.SQLServer.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace Storage.SQLServer
{
    public class DbAccount : Account, IAccount
    {
        readonly AccountManagementDbContext db;

        public DbAccount(AccountManagementDbContext db, Account account)
        {
            this.db = db;
            Id = account.Id;
            Balance = account.Balance;
            ClientId = account.ClientId;
            Client = account.Client;
        }

        public virtual async Task Recharge(decimal amount)
        {
            Balance += amount;

            // TODO: detach old entity first
            db.Accounts.Update(this);

            await db.SaveChangesAsync();
        }

        public virtual async Task Transfer(IAccount to, decimal amount)
        {
            Balance -= amount;
            to.Balance += amount;

            var tasks = new[] { Id, to.Id }.Select(id => db.Accounts.FindAsync(id).AsTask());

            var accounts = await Task.WhenAll(tasks);

            accounts[0].Balance = Balance;
            accounts[1].Balance = to.Balance;

            await db.SaveChangesAsync();
        }
    }
}
