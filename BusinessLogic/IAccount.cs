using System.Threading.Tasks;

namespace BusinessLogic
{
    /// <summary>
    /// Интерфейс счета
    /// </summary>
    public interface IAccount
    {
        int Id { get; }
        decimal Balance { get; }

        /// <summary>
        /// Пополнение баланса счета
        /// </summary>
        /// <param name="amount">сумма пополнения</param>
        /// <returns>некая асинхронная задача</returns>
        Task Recharge(decimal amount);
        
        /// <summary>
        /// Перевод с текущего счета на счет получателя
        /// </summary>
        /// <param name="to">счет получателя</param>
        /// <param name="amount">сумма перевода</param>
        /// <returns>некая асинхронная задача</returns>
        Task Transfer(IAccount to, decimal amount);
    }
}
