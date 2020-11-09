using BusinessLogic;
using BusinessLogic.Storage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Storage.InMemory
{
    public class ClientStorage<TClient> : IClientStorage
        where TClient : IClient
    {
        List<IClient> clients = new List<IClient>();
        Func<int, string, string, IEnumerable<IAccount>, IClient> clientFactory;
        int nextId = 1;

        public ClientStorage(Func<int, string, string, IEnumerable<IAccount>, IClient> clientFactory)
        {
            this.clientFactory = clientFactory;
        }

        public Task<int> Create(string firstName, string lastName)
        {
            var accounts = new IAccount[] { };
            var client = clientFactory(nextId++, firstName, lastName, accounts);

            clients.Add(client);

            return Task.FromResult(client.Id);
        }

        public Task<IClient> Get(int clientId)
        {
            // TODO: linear complexity!
            var client = clients.Find(c => c.Id == clientId);

            return Task.FromResult(client);
        }
    }
}
