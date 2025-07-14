using PersonalBudgetingApi.Models;
using PersonalBudgetingApi.Database;
using PersonalBudgetingApi.DTO;
using Microsoft.EntityFrameworkCore;
using PersonalBudgetingApi.Services.Interfaces;

namespace PersonalBudgetingApi.Services
{
    public class TransactionService(PersonalBudgetingDbContext context) : ITransactionService
    {
        private readonly PersonalBudgetingDbContext _context = context;

        public async Task<IEnumerable<Transaction>> GetAllAsync()
        {
            return await _context.Transactions
                .ToListAsync();
        }

        public Task<Transaction?> GetByIdAsync(int id)
        {
            var transaction = _context.Transactions.FirstOrDefault(t => t.Id == id);
            return Task.FromResult(transaction);
        }

        public async Task<Transaction> CreateAsync(TransactionDto dto)
        {
            var transaction = new Transaction
            {
                Amount = dto.Amount,
                Description = dto.Description,
                Date = dto.Date,
                CategoryId = dto.CategoryId,
                UserId = dto.UserId
            };

            var created = await _context.Transactions.AddAsync(transaction);
            await _context.SaveChangesAsync();

            return created.Entity;
        }

        public async Task<bool> UpdateAsync(int id, TransactionDto dto)
        {
            var transaction = await _context.Transactions
                .Include(t => t.Category)
                .FirstOrDefaultAsync(t => t.Id == id);

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
