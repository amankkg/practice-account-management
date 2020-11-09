using BusinessLogic;
using BusinessLogic.Storage;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Storage.InMemory
{
    /// <summary>
    /// Хранилище счетов в памяти
    /// </summary>
    public class InMemoryAccountStorage : IAccountStorage
    {
        Dictionary<int, List<IAccount>> accountBase = new Dictionary<int, List<IAccount>>();
        int nextId = 1;

        readonly Func<int, decimal, IAccount> accountFactory;

        /// <summary>
        /// Конструктор хранилища счетов в памяти
        /// </summary>
        /// <param name="accountFactory">Фабричный метод счета с параметрами ИД (int) и Баланс (decimal)</param>
        public InMemoryAccountStorage(Func<int, decimal, IAccount> accountFactory)
        {
            this.accountFactory = accountFactory;
        }

        public Task<int> Create(IClient owner)
        {
            var account = accountFactory(nextId++, 0);

            if (!accountBase.ContainsKey(owner.Id))
            {
                accountBase.Add(owner.Id, new List<IAccount>());
                owner.Accounts = accountBase[owner.Id];
            }

            accountBase[owner.Id].Add(account);

            return Task.FromResult(account.Id);
        }

        public Task<IEnumerable<IAccount>> GetAll(IClient owner)
        {
            return Task.FromResult(accountBase[owner.Id] as IEnumerable<IAccount>);
        }

        public Task<IAccount> GetMain(IClient owner)
        {
            return Task.FromResult(accountBase[owner.Id][0]);
        }
    }
}
