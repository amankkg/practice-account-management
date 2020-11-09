﻿using BusinessLogic.Storage;
using Storage.InMemory;
using System.Linq;
using System.Threading.Tasks;

namespace UI
{
    class Program
    {
        readonly static IClientStorage clientStorage;
        readonly static IAccountStorage accountStorage;

        static Program()
        {
            clientStorage = new InMemoryClientStorage(ConsoleClient.Create);
            accountStorage = new InMemoryAccountStorage(ConsoleAccount.Create);
        }

        static async Task Main(string[] args)
        {
            // 1. создать аккаунты
            var johnDoeId = await clientStorage.Create("John", "Doe");
            var janeDoeId = await clientStorage.Create("Jane", "Doe");
            
            var johnDoe = await clientStorage.Get(johnDoeId);
            var janeDoe = await clientStorage.Get(janeDoeId);

            // 2. создать счета
            await accountStorage.Create(johnDoe);
            await accountStorage.Create(janeDoe);

            var johnDoeAcc = (await accountStorage.GetAll(johnDoe)).First();
            var janeDoeAcc = (await accountStorage.GetAll(janeDoe)).First();

            // 3. пополнить счет
            await johnDoeAcc.Recharge(100);

            await johnDoe.PrintSummary();
            await janeDoe.PrintSummary();

            // 4. сделать перевод
            await johnDoeAcc.Transfer(janeDoeAcc, 50);

            await johnDoe.PrintSummary();
            await janeDoe.PrintSummary();
        }
    }
}
