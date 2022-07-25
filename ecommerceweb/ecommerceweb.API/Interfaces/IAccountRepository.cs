using ecommerceweb.API.Models;

namespace ecommerceweb.API.Interfaces
{
    public interface IAccountRepository
    {
        Task<List<Account>> GetAsync();
        Task<Account> GetByIdAsync(int accountId);
        Task<Account> PostAsync(Account account);
        Task<Account> PutAsync(int accountId, Account account);
        Task DeleteAsync(int accountId);
    }
}
