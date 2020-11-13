using Storage.SQLServer;
using Storage.SQLServer.Entities;
using System;
using System.Threading.Tasks;

namespace UI
{
    /// <summary>
    /// Реализация интерфейса IClient для консольного приложения
    /// </summary>
    class ConsoleClient : DbClient
    {
        /// <summary>
        /// Фабричный метод клиента для БД
        /// </summary>
        /// <param name="client">Сущность клинета БД</param>
        /// <returns>Объект клиента</returns>
        public static ConsoleClient CreateFromDbEntity(Client client)
        {
            return new ConsoleClient
            {
                Id = client.Id,
                FirstName = client.FirstName,
                LastName = client.LastName
            };
        }

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

        public override Task PrintSummary()
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
