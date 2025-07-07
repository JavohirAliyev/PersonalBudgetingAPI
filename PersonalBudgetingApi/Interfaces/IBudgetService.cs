using PersonalBudgetingApi.Models;

namespace PersonalBudgetingApi.Interfaces;

public interface IBudgetService
{
    Task<BudgetDto?> CreateBudgetAsync(BudgetCreateDto dto, int userId);
    Task<List<BudgetDto>> GetBudgetsAsync(int userId);
    Task<BudgetDto?> GetBudgetByIdAsync(int id, int userId);
    Task<bool> UpdateBudgetAsync(int id, BudgetUpdateDto dto, int userId);
    Task<bool> DeleteBudgetAsync(int id, int userId);
}
