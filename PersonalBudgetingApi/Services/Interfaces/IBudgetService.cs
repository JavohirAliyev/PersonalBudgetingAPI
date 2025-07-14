using PersonalBudgetingApi.DTO;

namespace PersonalBudgetingApi.Services.Interfaces;

public interface IBudgetService
{
    Task<BudgetDto?> CreateBudgetAsync(BudgetDto dto, int userId);
    Task<List<BudgetDto>> GetBudgetsAsync(int userId);
    Task<BudgetDto?> GetBudgetByIdAsync(int id, int userId);
    Task<bool> UpdateBudgetAsync(int id, BudgetDto dto, int userId);
    Task<bool> DeleteBudgetAsync(int id, int userId);
}
