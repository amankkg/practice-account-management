using BusinessLogic;
using BusinessLogic.Storage;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Storage.InMemory
{
    public class AccountStorage : IAccountStorage
    {
        Dictionary<int, List<IAccount>> accountBase = new Dictionary<int, List<IAccount>>();
        Func<int, decimal, IAccount> accountFactory;
        int nextId = 1;

        public AccountStorage(Func<int, decimal, IAccount> accountFactory)
        {
            this.accountFactory = accountFactory;
        }

        public Task<int> Create(IClient owner)
        {
            var account = accountFactory(nextId++, 0);

            if (accountBase.ContainsKey(owner.Id))
            {
                accountBase[owner.Id].Add(account);
            }
            else
            {
                accountBase.Add(owner.Id, new List<IAccount> { account });
            }

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
