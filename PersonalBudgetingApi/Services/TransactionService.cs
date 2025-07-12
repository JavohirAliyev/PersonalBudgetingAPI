using PersonalBudgetingApi.Models;
using PersonalBudgetingApi.Data;
using PersonalBudgetingApi.DTO;
using Microsoft.EntityFrameworkCore;

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

        public async Task<bool> UpdateAsync(TransactionUpdateDto dto)
        {
            var transaction = await _context.transactions
                .Include(t => t.Category)
                .FirstOrDefaultAsync(t => t.Id == dto.Id);

            if (transaction == null)
                return false;

            transaction.Amount = dto.Amount;
            transaction.Description = dto.Description;
            transaction.Date = dto.Date;

            var category = await _context.categories.FindAsync(dto.CategoryId);
            if (category == null)
                return false;

            transaction.Category = category;

            return true;
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
