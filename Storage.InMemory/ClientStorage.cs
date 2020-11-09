using BusinessLogic;
using BusinessLogic.Storage;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Storage.InMemory
{
    /// <summary>
    /// Хранилище клиентов в памяти
    /// </summary>
    public class ClientStorage : IClientStorage
    {
        List<IClient> clients = new List<IClient>();
        Func<int, string, string, IEnumerable<IAccount>, IClient> clientFactory;
        int nextId = 1;

        /// <summary>
        /// Конструктор хранилища клиентов в памяти
        /// </summary>
        /// <param name="clientFactory">Фабричный метод клиента с параметрами ИД (int), Имя (string), Фамилия (string) и счета клиента (IEnumerable\<IAccount\>)</param>
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
