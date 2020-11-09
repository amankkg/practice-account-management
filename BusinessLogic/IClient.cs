using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public interface IClient
    {
        int Id { get; }
        string FirstName { get; }
        string LastName { get; }
        IEnumerable<IAccount> Accounts { get; }
        Task PrintSummary();
    }
}
