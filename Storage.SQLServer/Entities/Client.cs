using System.Collections.Generic;

namespace Storage.SQLServer.Entities
{
    public class Client
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<Account> Accounts { get; set; }
    }
}
