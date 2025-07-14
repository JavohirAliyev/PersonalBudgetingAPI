using PersonalBudgetingApi.DTO;
using PersonalBudgetingApi.Models;

namespace PersonalBudgetingApi.Services.Interfaces;

public interface ICategoryService
{
    Task<IEnumerable<Category>> GetAllAsync();
    Task<Category?> GetByIdAsync(int id);
    Task<Category> CreateAsync(Category category);
    Task<bool> UpdateAsync(CategoryDto dto);
    Task<bool> DeleteAsync(int id);
}