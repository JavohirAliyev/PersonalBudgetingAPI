using Microsoft.AspNetCore.Identity;
using PersonalBudgetingApi.Models;
using PersonalBudgetingApi.Data;

namespace PersonalBudgetingApi.Services;

public class CategoriesService(PersonalBudgetingDbContext context) : ICategoryService
{
    private readonly PersonalBudgetingDbContext _context = context;

    public Task<IEnumerable<Category>> GetAllAsync()
    {
        return Task.FromResult(_context.categories.AsEnumerable());
    }

    public async Task<Category?> GetByIdAsync(int id)
    {
        return await _context.categories.FindAsync(id);
    }

    public Task<Category> CreateAsync(Category category)
    {
        _context.categories.Add(category);
        _context.SaveChanges();
        return Task.FromResult(category);
    }

    public async Task<bool> UpdateAsync(Category category)
    {
        var existingCategory = await _context.categories.FindAsync(category.Id);
        if (existingCategory == null)
            return false;

        _context.Entry(existingCategory).CurrentValues.SetValues(category);
        await _context.SaveChangesAsync();
        return true;
    }
    public async Task<bool> DeleteAsync(int id)
    {
        var category = await _context.categories.FindAsync(id);
        if (category == null)
            return false;

        _context.categories.Remove(category);
        await _context.SaveChangesAsync();
        return true;
    }
}
