using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UI
{
    class ConsoleClient : IClient
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IEnumerable<IAccount> Accounts { get; set; }

        public Task PrintSummary()
        {
            Console.WriteLine($"First name: {FirstName}");
            Console.WriteLine($"Last name: {LastName}");
            Console.WriteLine("\nAccounts:");
            Console.WriteLine("\n№\tBalance");

            foreach (var acc in Accounts)
            {
                Console.WriteLine($"{acc.Id}\t{acc.Balance}");
            }

            return Task.CompletedTask;
        }
    }
}
