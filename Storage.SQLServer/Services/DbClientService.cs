using BusinessLogic;
using BusinessLogic.Services;
using Microsoft.EntityFrameworkCore;
using Storage.SQLServer.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Storage.SQLServer.Services
{
    public class DbClientService : IClientService
    {
        readonly AccountManagementDbContext db;
        readonly Func<Client, DbClient> clientFactory;

        public DbClientService(AccountManagementDbContext db, Func<Client, DbClient> clientFactory)
        {
            this.db = db;
            this.clientFactory = clientFactory;
        }

        public async Task<int> Create(string firstName, string lastName)
        {
            var client = new Client
            {
                FirstName = firstName,
                LastName = lastName
            };

            db.Clients.Add(client);

            await db.SaveChangesAsync();

            return client.Id;
        }

        public async Task<IClient> Get(int clientId)
        {
            var client = await db.Clients
                .Include(c => c.Accounts)
                .FirstAsync(c => c.Id == clientId);

            return clientFactory(client);
        }
    }
}
