using PersonalBudgetingApi.Models;
using PersonalBudgetingApi.Data;

namespace PersonalBudgetingApi.Services
{
    public class TransactionService(PersonalBudgetingDbContext context) : ITransactionService
    {
        private readonly PersonalBudgetingDbContext _context = context;

        public Task<IEnumerable<Transaction>> GetAllAsync()
        {
            return Task.FromResult(_context.transactions.AsEnumerable());
        }

        public Task<Transaction?> GetByIdAsync(int id)
        {
            var transaction = _context.transactions.FirstOrDefault(t => t.Id == id);
            return Task.FromResult(transaction);
        }

        public Task<Transaction> CreateAsync(Transaction transaction)
        {
            _context.transactions.Add(transaction);
            return Task.FromResult(transaction);
        }

        public Task<bool> UpdateAsync(Transaction transaction)
        {
            var existing = _context.transactions.FirstOrDefault(t => t.Id == transaction.Id);
            if (existing == null)
            {
                return Task.FromResult(false);
            }

            existing.Amount = transaction.Amount;
            existing.Description = transaction.Description;
            existing.Date = transaction.Date;
            existing.Category = transaction.Category;

            return Task.FromResult(true);
        }

        public Task<bool> DeleteAsync(int id)
        {
            var transaction = _context.transactions.FirstOrDefault(t => t.Id == id);
            if (transaction == null)
            {
                return Task.FromResult(false);
            }

            _context.transactions.Remove(transaction);
            return Task.FromResult(true);
        }
    }
}