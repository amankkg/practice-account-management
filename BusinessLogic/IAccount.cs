using System.Threading.Tasks;

namespace BusinessLogic
{
    public interface IAccount
    {
        int Id { get; set; }
        decimal Balance { get; set; }
        Task Recharge(decimal amount);
        Task Transfer(IAccount to, decimal amount);
    }
}
