using ecommerceweb.API.Interfaces;
using ecommerceweb.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ecommerceweb.API.Data.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly APIDbContext _context;
        public AccountRepository(APIDbContext context)
        {
            _context = context;
        }
        public async Task<List<Account>> GetAsync()
        {
            return await _context.Accounts.ToListAsync();
        }
        public async Task<Account> GetByIdAsync(int accountId)
        {
            //return await _context.Accounts.FirstOrDefaultAsync(item => item.AccountId == accountId);
            throw new NotImplementedException();
        }
        public async Task<Account> PostAsync(Account account)
        {
            /*_context.Accounts.Add(account);
            await _context.SaveChangesAsync();
            return account;*/
            throw new NotImplementedException();
        }
        public async Task<Account> PutAsync(int accountId, Account account)
        {
            /*var getAccount = await _context.Accounts.FirstOrDefaultAsync(item => item.AccountId == accountId);
            getAccount.CategoryName = category.CategoryName;
            getAccount.Description = category.Description;
            getAccount.Ordering = category.Ordering;
            getAccount.Published = category.Published;
            await _context.SaveChangesAsync();
            return getAccount;*/
            throw new NotImplementedException();

        }
        public async Task DeleteAsync(int accountId)
        {
            throw new NotImplementedException();
        }
    }
}
