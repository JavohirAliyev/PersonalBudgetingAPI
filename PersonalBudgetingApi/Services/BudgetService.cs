using PersonalBudgetingApi.Models;
using PersonalBudgetingApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using PersonalBudgetingApi.Database;
using PersonalBudgetingApi.DTO;

namespace PersonalBudgetingApi.Services;

public class BudgetService(PersonalBudgetingDbContext context) : IBudgetService
{
    private readonly PersonalBudgetingDbContext _context = context;

    public async Task<Budget> CreateBudgetAsync(BudgetDto dto, int userId)
    {
        var budget = new Budget
        {
            Name = dto.Name,
            Limit = dto.Limit,
            UserId = userId
        };

        var created = await _context.Budgets.AddAsync(budget);
        await _context.SaveChangesAsync();

        return created.Entity;
    }

    public async Task<List<BudgetDto>> GetBudgetsAsync(int userId)
    {
        return await _context.Budgets
            .Where(b => b.UserId == userId)
            .Select(b => new BudgetDto
            {
                Name = b.Name!,
                Limit = b.Limit
            })
            .ToListAsync();
    }

    public async Task<BudgetDto?> GetBudgetByIdAsync(int id, int userId)
    {
        return await _context.Budgets
            .Where(b => b.Id == id && b.UserId == userId)
            .Select(b => new BudgetDto
            {
                Name = b.Name!,
                Limit = b.Limit
            })
            .FirstOrDefaultAsync();
    }

    public async Task<bool> UpdateBudgetAsync(int id, BudgetDto dto, int userId)
    {
        var budget = await _context.Budgets.FirstOrDefaultAsync(b => b.Id == id && b.UserId == userId);
        if (budget == null) return false;

        budget.Name = dto.Name;
        budget.Limit = dto.Limit;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteBudgetAsync(int id, int userId)
    {
        var budget = await _context.Budgets.FirstOrDefaultAsync(b => b.Id == id && b.UserId == userId);
        if (budget == null) return false;

        _context.Budgets.Remove(budget);
        await _context.SaveChangesAsync();
        return true;
    }
}
