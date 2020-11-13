using BusinessLogic;
using BusinessLogic.Services;
using Microsoft.EntityFrameworkCore;
using Storage.SQLServer.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Storage.SQLServer.Services
{
    public class DbAccountService : IAccountService
    {
        readonly AccountManagementDbContext db;

        public DbAccountService(AccountManagementDbContext db)
        {
            this.db = db;
        }

        public async Task<int> Create(IClient owner)
        {
            var account = new Account
            {
                ClientId = owner.Id,
                Balance = 0,
            };

            db.Accounts.Add(account);

            await db.SaveChangesAsync();

            return account.Id;
        }

        public async Task<IEnumerable<IAccount>> GetAll(IClient owner)
        {
            var accounts = await db.Accounts
                .Where(a => a.ClientId == owner.Id)
                .ToListAsync();

            return accounts.Select(a => new DbAccount(db, a));
        }

        public async Task<IAccount> GetMain(IClient owner)
        {
            var account = await db.Accounts.FirstAsync(a => a.ClientId == owner.Id);

            return new DbAccount(db, account);
        }
    }
}
