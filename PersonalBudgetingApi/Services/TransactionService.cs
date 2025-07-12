using PersonalBudgetingApi.Models;
using PersonalBudgetingApi.Database;
using PersonalBudgetingApi.DTO;
using Microsoft.EntityFrameworkCore;

namespace PersonalBudgetingApi.Services
{
    public class Transactionservice(PersonalBudgetingDbContext context) : ITransactionService
    {
        private readonly PersonalBudgetingDbContext _context = context;

        public Task<IEnumerable<Transaction>> GetAllAsync()
        {
            return Task.FromResult(_context.Transactions.AsEnumerable());
        }

        public Task<Transaction?> GetByIdAsync(int id)
        {
            var transaction = _context.Transactions.FirstOrDefault(t => t.Id == id);
            return Task.FromResult(transaction);
        }

        public Task<Transaction> CreateAsync(Transaction transaction)
        {
            _context.Transactions.Add(transaction);
            return Task.FromResult(transaction);
        }

        public async Task<bool> UpdateAsync(TransactionUpdateDto dto)
        {
            var transaction = await _context.Transactions
                .Include(t => t.Category)
                .FirstOrDefaultAsync(t => t.Id == dto.Id);

            if (transaction == null)
                return false;

            transaction.Amount = dto.Amount;
            transaction.Description = dto.Description;
            transaction.Date = dto.Date;

            var category = await _context.Categories.FindAsync(dto.CategoryId);
            if (category == null)
                return false;

            transaction.Category = category;

            return true;
        }

        public Task<bool> DeleteAsync(int id)
        {
            var transaction = _context.Transactions.FirstOrDefault(t => t.Id == id);
            if (transaction == null)
            {
                return Task.FromResult(false);
            }

            _context.Transactions.Remove(transaction);
            return Task.FromResult(true);
        }
    }
}
