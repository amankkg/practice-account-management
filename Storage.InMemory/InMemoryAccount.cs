using BusinessLogic;
using System.Threading.Tasks;

namespace Storage.InMemory
{
    /// <summary>
    /// Реализация интерфейса IAccount в памяти
    /// </summary>
    public class InMemoryAccount : IAccount
    {
        public int Id { get; private set; }
        public decimal Balance { get; set; }

        /// <summary>
        /// Конструктор счета в памати
        /// </summary>
        /// <param name="id">ИД счета</param>
        /// <param name="balance">Баланс счета</param>
        public InMemoryAccount(int id, decimal balance)
        {
            Id = id;
            Balance = balance;
        }

        public virtual Task Recharge(decimal amount)
        {
            Balance += amount;
            return Task.CompletedTask;
        }

        public virtual Task Transfer(IAccount to, decimal amount)
        {
            Balance -= amount;
            to.Balance += amount;
            return Task.CompletedTask;
        }
    }
}
