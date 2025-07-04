using PersonalBudgetingApi.Models;
using System.Collections.Concurrent;

namespace PersonalBudgetingApi.Services;

public class CategoriesService : ICategoryService
{
    private readonly ConcurrentDictionary<int, Category> _categories = new();
    private int _nextId = 1;

    public Task<IEnumerable<Category>> GetAllAsync()
    {
        return Task.FromResult(_categories.Values.AsEnumerable());
    }

    public Task<Category?> GetByIdAsync(int id)
    {
        _categories.TryGetValue(id, out var category);
        return Task.FromResult(category);
    }

    public Task<Category> CreateAsync(Category category)
    {
        category.Id = _nextId++;
        _categories[category.Id] = category;
        return Task.FromResult(category);
    }

    public Task<bool> UpdateAsync(Category category)
    {
        if (!_categories.ContainsKey(category.Id))
            return Task.FromResult(false);

        _categories[category.Id] = category;
        return Task.FromResult(true);
    }

    public Task<bool> DeleteAsync(int id)
    {
        return Task.FromResult(_categories.TryRemove(id, out _));
    }
}
