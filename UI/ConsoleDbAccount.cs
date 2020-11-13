using BusinessLogic;
using Storage.SQLServer;
using Storage.SQLServer.Entities;
using System;
using System.Threading.Tasks;

namespace UI
{
    class ConsoleDbAccount : DbAccount
    {
        // TODO: fix `Storage.SQLServer.Entities.Account` is public - leaking abstraction
        public ConsoleDbAccount(AccountManagementDbContext db, Account account)
            : base(db, account)
        {
        }

        public override Task Recharge(decimal amount)
        {
            Console.WriteLine($"Recharging account #{Id} by ${amount}");

            return base.Recharge(amount);
        }

        public override Task Transfer(IAccount to, decimal amount)
        {
            Console.WriteLine($"Transfering ${amount} from #{Id} to #{to.Id}");
            return base.Transfer(to, amount);
        }
    }
}
