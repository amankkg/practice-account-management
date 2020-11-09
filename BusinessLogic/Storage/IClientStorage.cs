using System.Threading.Tasks;

namespace BusinessLogic.Storage
{
    /// <summary>
    /// Хранилище клиентов
    /// </summary>
    public interface IClientStorage
    {
        /// <summary>
        /// Регистрация нового клиента
        /// </summary>
        /// <param name="firstName">Имя клиента</param>
        /// <param name="lastName">Фамилия клиента</param>
        /// <returns>некая асинхронная задача, возвращает ИД нового клиента</returns>
        Task<int> Create(string firstName, string lastName);

        /// <summary>
        /// Получение клиента по его ИД
        /// </summary>
        /// <param name="clientId">ИД клиента</param>
        /// <returns>некая асинхронная задача, возвращает клиента</returns>
        Task<IClient> Get(int clientId);
    }
}
