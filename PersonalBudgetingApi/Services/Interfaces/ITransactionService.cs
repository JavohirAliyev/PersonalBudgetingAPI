using PersonalBudgetingApi.DTO;
using PersonalBudgetingApi.Models;

namespace PersonalBudgetingApi.Services.Interfaces
{
    public interface ITransactionService
    {
        Task<IEnumerable<Transaction>> GetAllAsync();
        Task<Transaction?> GetByIdAsync(int id);
        Task<Transaction> CreateAsync(TransactionDto dto);
        Task<bool> UpdateAsync(int id, TransactionDto dto);
        Task<bool> DeleteAsync(int id);
    }
}