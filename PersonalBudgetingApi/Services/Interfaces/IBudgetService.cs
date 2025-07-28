using PersonalBudgetingApi.DTO;
using PersonalBudgetingApi.Models;

namespace PersonalBudgetingApi.Services.Interfaces;

public interface IBudgetService
{
    Task<Budget> CreateBudgetAsync(BudgetDto dto, int userId);
    Task<List<BudgetDto>> GetBudgetsAsync(int userId, int pageSize, int pageNumber);
    Task<BudgetDto?> GetBudgetByIdAsync(int id, int userId);
    Task<bool> UpdateBudgetAsync(int id, BudgetDto dto, int userId);
    Task<bool> DeleteBudgetAsync(int id, int userId);
}
