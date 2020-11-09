using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Storage
{
    /// <summary>
    /// Интерфейс хранилища счетов
    /// </summary>
    public interface IAccountStorage
    {
        /// <summary>
        /// Открытие нового счета
        /// </summary>
        /// <param name="owner">Клиент, владелец счета</param>
        /// <returns>некая асинхронная задача, возвращает ИД нового счета</returns>
        Task<int> Create(IClient owner);

        /// <summary>
        /// Получение всех счетов клиента
        /// </summary>
        /// <param name="owner">Клиент, владелец счетов</param>
        /// <returns>некая асинхронная задача, возвращает счета</returns>
        Task<IEnumerable<IAccount>> GetAll(IClient owner);

        /// <summary>
        /// Получение основного счета клиента
        /// </summary>
        /// <param name="owner">Клиент, владелец счета</param>
        /// <returns>некая асинхронная задача, возвращает счет</returns>
        Task<IAccount> GetMain(IClient owner);
    }
}
