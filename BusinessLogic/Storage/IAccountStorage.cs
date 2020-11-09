using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Storage
{
    public interface IAccountStorage
    {
        Task<int> Create(IClient owner);
        Task<IEnumerable<IAccount>> GetAll(IClient owner);
        Task<IAccount> GetMain(IClient owner);
    }
}
