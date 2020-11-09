using BusinessLogic;
using Storage.InMemory;
using System;
using System.Threading.Tasks;

namespace UI
{
    class ConsoleAccount : InMemoryAccount
    {
        /// <summary>
        /// Приватный конструктор консольного счета для фабричного метода Create
        /// </summary>
        /// <param name="id">ИД счета</param>
        /// <param name="balance">Баланс счета</param>
        private ConsoleAccount(int id, decimal balance)
            : base(id, balance)
        {
        }

        /// <summary>
        /// Фабричный метод консольного счета
        /// </summary>
        /// <param name="id">ИД счета</param>
        /// <param name="balance">Баланс счета</param>
        /// <returns>Объект счета</returns>
        public static ConsoleAccount Create(int id, decimal balance)
        {
            return new ConsoleAccount(id, balance);
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
