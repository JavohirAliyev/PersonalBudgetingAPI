using PersonalBudgetingApi.Models;

namespace PersonalBudgetingApi.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly List<Transaction> _transactions = [];
        private int _nextId = 1;

        public Task<IEnumerable<Transaction>> GetAllAsync()
        {
            return Task.FromResult(_transactions.AsEnumerable());
        }

        public Task<Transaction?> GetByIdAsync(int id)
        {
            var transaction = _transactions.FirstOrDefault(t => t.Id == id);
            return Task.FromResult(transaction);
        }

        public Task<Transaction> CreateAsync(Transaction transaction)
        {
            transaction.Id = _nextId++;
            _transactions.Add(transaction);
            return Task.FromResult(transaction);
        }

        public Task<bool> UpdateAsync(Transaction transaction)
        {
            var existing = _transactions.FirstOrDefault(t => t.Id == transaction.Id);
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
            var transaction = _transactions.FirstOrDefault(t => t.Id == id);
            if (transaction == null)
            {
                return Task.FromResult(false);
            }

            _transactions.Remove(transaction);
            return Task.FromResult(true);
        }
    }
}