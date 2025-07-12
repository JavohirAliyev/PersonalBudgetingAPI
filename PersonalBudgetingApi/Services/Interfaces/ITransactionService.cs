using PersonalBudgetingApi.DTO;
using PersonalBudgetingApi.Models;

namespace PersonalBudgetingApi.Services
{
    public interface ITransactionService
    {
        Task<IEnumerable<Transaction>> GetAllAsync();
        Task<Transaction?> GetByIdAsync(int id);
        Task<Transaction> CreateAsync(Transaction transaction);
        Task<bool> UpdateAsync(TransactionUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}