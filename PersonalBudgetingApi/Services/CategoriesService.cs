using PersonalBudgetingApi.Models;
using PersonalBudgetingApi.Database;
using PersonalBudgetingApi.DTO;
using PersonalBudgetingApi.Services.Interfaces;

namespace PersonalBudgetingApi.Services;

public class CategoriesService(PersonalBudgetingDbContext context) : ICategoryService
{
    private readonly PersonalBudgetingDbContext _context = context;

    public async Task<List<Category>> GetAllAsync()
    {
        var categories = _context.Categories
            .ToList();
        return await Task.FromResult(categories);
    }

    public async Task<Category?> GetByIdAsync(int id)
    {
        return await _context.Categories.FindAsync(id);
    }

    public Task<Category> CreateAsync(Category category)
    {
        _context.Categories.Add(category);
        _context.SaveChanges();
        return Task.FromResult(category);
    }

    public async Task<bool> UpdateAsync(int id, CategoryDto category)
    {
        var existingCategory = await _context.Categories.FindAsync(id);
        if (existingCategory == null)
            return false;

        _context.Entry(existingCategory).CurrentValues.SetValues(category);
        await _context.SaveChangesAsync();
        return true;
    }
    public async Task<bool> DeleteAsync(int id)
    {
        var category = await _context.Categories.FindAsync(id);
        if (category == null)
            return false;

        _context.Categories.Remove(category);
        await _context.SaveChangesAsync();
        return true;
    }
}
