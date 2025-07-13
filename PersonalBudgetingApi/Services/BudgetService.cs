using PersonalBudgetingApi.Models;
using PersonalBudgetingApi.Interfaces;
using Microsoft.EntityFrameworkCore;
using PersonalBudgetingApi.Data;

namespace PersonalBudgetingApi.Services;

public class BudgetService : IBudgetService
{
    private readonly AppDbContext _context;

    public BudgetService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<BudgetDto?> CreateBudgetAsync(BudgetCreateDto dto, int userId)
    {
        var budget = new Budget
        {
            Name = dto.Name,
            Limit = dto.Limit,
            UserId = userId
        };

        _context.Budgets.Add(budget);
        await _context.SaveChangesAsync();

        return new BudgetDto
        {
            Id = budget.Id,
            Name = budget.Name,
            Limit = budget.Limit
        };
    }

    public async Task<List<BudgetDto>> GetBudgetsAsync(int userId)
    {
        return await _context.Budgets
            .Where(b => b.UserId == userId)
            .Select(b => new BudgetDto
            {
                Id = b.Id,
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
                Id = b.Id,
                Name = b.Name!,
                Limit = b.Limit
            })
            .FirstOrDefaultAsync();
    }

    public async Task<bool> UpdateBudgetAsync(int id, BudgetUpdateDto dto, int userId)
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
