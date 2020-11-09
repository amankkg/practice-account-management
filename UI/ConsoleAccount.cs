using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UI
{
    /// <summary>
    /// Реализация интерфейса IAccount для консольного приложения
    /// </summary>
    class ConsoleAccount : IAccount
    {
        public int Id { get; private set; }
        public decimal Balance { get; private set; }

        /// <summary>
        /// Фабричный метод консольного счета
        /// </summary>
        /// <param name="id">ИД счета</param>
        /// <param name="balance">Баланс счета</param>
        /// <returns>Объект счета</returns>
        public static ConsoleAccount Create(int id, decimal balance)
        {
            return new ConsoleAccount
            {
                Id = id,
                Balance = balance
            };
        }

        public Task Recharge(decimal amount)
        {
            throw new NotImplementedException();
        }

        public Task Transfer(IAccount to, decimal amount)
        {
            throw new NotImplementedException();
        }
    }
}
