using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UI
{
    /// <summary>
    /// Реализация интерфейса IClient для консольного приложения
    /// </summary>
    class ConsoleClient : IClient
    {
        public int Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public IEnumerable<IAccount> Accounts { get; set; }

        /// <summary>
        /// Фабричный метод консольного клиента
        /// </summary>
        /// <param name="id">ИД клиента</param>
        /// <param name="firstName">Имя клиента</param>
        /// <param name="lastName">Фамилия клиента</param>
        /// <param name="accounts">Счета клиента</param>
        /// <returns>Объект клиента</returns>
        public static ConsoleClient Create(int id, string firstName, string lastName)
        {
            return new ConsoleClient
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName
            };
        }

        public Task PrintSummary()
        {
            Console.WriteLine($"Summary of #{Id}");
            Console.WriteLine($"\tFirst name: {FirstName}");
            Console.WriteLine($"\tLast name: {LastName}");
            Console.WriteLine("\nAccounts:");
            Console.WriteLine("\n\t#\tBalance");

            foreach (var acc in Accounts)
            {
                Console.WriteLine($"\t{acc.Id}\t${acc.Balance}");
            }

            return Task.CompletedTask;
        }
    }
}
