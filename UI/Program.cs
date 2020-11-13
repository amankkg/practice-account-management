using BusinessLogic.Services;
using Storage.InMemory;
using Storage.SQLServer;
using Storage.SQLServer.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace UI
{
    class Program
    {
        static IClientService clientService;
        static IAccountService accountService;

        static async Task Main(string[] args)
        {
            // 0. инициализировать хранилища сущностей
            Console.WriteLine("Which storage you want to use?\n\t- in-memory storage [1]\n\t- database storage [2]\n");
            var storageInput = Console.ReadLine();
            var storageNum = int.Parse(storageInput);

            await InitServices(storageNum);

            // 1. создать аккаунты
            var johnDoeId = await clientService.Create("John", "Doe");
            var janeDoeId = await clientService.Create("Jane", "Doe");
            
            var johnDoe = await clientService.Get(johnDoeId);
            var janeDoe = await clientService.Get(janeDoeId);

            // 2. создать счета
            await accountService.Create(johnDoe);
            await accountService.Create(janeDoe);

            var johnDoeAcc = (await accountService.GetAll(johnDoe)).First();
            var janeDoeAcc = (await accountService.GetAll(janeDoe)).First();

            // 3. пополнить счет
            await johnDoeAcc.Recharge(100);

            await johnDoe.PrintSummary();
            await janeDoe.PrintSummary();

            // 4. сделать перевод
            await johnDoeAcc.Transfer(janeDoeAcc, 50);

            await johnDoe.PrintSummary();
            await janeDoe.PrintSummary();
        }

        static async Task InitServices(int storage)
        {
            switch (storage)
            {
                case 1:
                    clientService = new InMemoryClientStorage(ConsoleClient.Create);
                    accountService = new InMemoryAccountStorage(ConsoleAccount.Create);

                    break;
                case 2:
                    var db = new AccountManagementDbContext();
                    
                    clientService = new DbClientService(db, ConsoleClient.CreateFromDbEntity);
                    accountService = new DbAccountService(db);

                    break;
                default:
                    throw new Exception("Storage not found");
            }

            await Task.CompletedTask;
        }
    }
}
