using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic
{
    /// <summary>
    /// Интерфейс клиента, держателя счетов
    /// </summary>
    public interface IClient
    {
        int Id { get; }
        string FirstName { get; }
        string LastName { get; }
        
        /// <summary>
        /// Счета клиента в базе
        /// </summary>
        IEnumerable<IAccount> Accounts { get; set; }
        
        /// <summary>
        /// Вывод состояния всех счетов клиента
        /// </summary>
        /// <returns>некая асинхронная задача</returns>
        Task PrintSummary();
    }
}
