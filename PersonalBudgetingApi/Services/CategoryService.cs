using Microsoft.AspNetCore.Identity;
using PersonalBudgetingApi.Models;
using PersonalBudgetingApi.Data;
using PersonalBudgetingApi.DTO;

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

    public async Task<bool> UpdateAsync(CategoryUpdateDto dto)
    {
        var category = await _context.categories.FindAsync(dto.Id);
        if (category == null)
            return false;

        category.Name = dto.Name;
        category.Type = dto.Type;

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
