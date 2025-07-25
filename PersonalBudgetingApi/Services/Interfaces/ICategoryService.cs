using PersonalBudgetingApi.DTO;
using PersonalBudgetingApi.Models;

namespace PersonalBudgetingApi.Services.Interfaces;

public interface ICategoryService
{
    Task<List<Category>> GetAllAsync();
    Task<Category?> GetByIdAsync(int id);
    Task<Category> CreateAsync(Category category);
    Task<bool> UpdateAsync(int id, CategoryDto dto);
    Task<bool> DeleteAsync(int id);
}