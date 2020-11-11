using Microsoft.EntityFrameworkCore;
using Storage.SQLServer.Entities;

namespace Storage.SQLServer
{
    public class AccountManagementDbContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Account> Accounts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
            => builder.UseSqlServer(@"Server=AMANK-XPS-9360\SQLEXPRESS; Database=AccountManagement; Integrated Security=true");
    }
}
