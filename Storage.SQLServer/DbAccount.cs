using BusinessLogic;
using Storage.SQLServer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Storage.SQLServer
{
    public class DbAccount : Account, IAccount
    {
        readonly AccountManagementDbContext dbContext;

        public DbAccount(AccountManagementDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public virtual async Task Recharge(decimal amount)
        {
            // TODO: сделать изменения в контексте БД
            await dbContext.SaveChangesAsync();
        }

        public virtual async Task Transfer(IAccount to, decimal amount)
        {
            // TODO: сделать изменения в контексте БД
            await dbContext.SaveChangesAsync();
        }
    }
}
