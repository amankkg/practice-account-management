using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Storage
{
    public interface IClientStorage
    {
        Task<int> Create(string firstName, string lastName);
        Task<IClient> Get(int clientId);
    }
}
