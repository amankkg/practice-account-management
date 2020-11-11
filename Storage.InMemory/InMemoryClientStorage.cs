using BusinessLogic;
using BusinessLogic.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Storage.InMemory
{
    /// <summary>
    /// Хранилище клиентов в памяти
    /// </summary>
    public class InMemoryClientStorage : IClientService
    {
        List<IClient> clients = new List<IClient>();
        Func<int, string, string, IClient> clientFactory;
        int nextId = 1;

        /// <summary>
        /// Конструктор хранилища клиентов в памяти
        /// </summary>
        /// <param name="clientFactory">Фабричный метод клиента с параметрами ИД (int), Имя (string), Фамилия (string) и счета клиента (IEnumerable\<IAccount\>)</param>
        public InMemoryClientStorage(Func<int, string, string, IClient> clientFactory)
        {
            this.clientFactory = clientFactory;
        }

        public Task<int> Create(string firstName, string lastName)
        {
            var client = clientFactory(nextId++, firstName, lastName);

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
