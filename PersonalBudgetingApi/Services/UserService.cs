using Microsoft.EntityFrameworkCore;
using PersonalBudgetingApi.Interfaces;
using PersonalBudgetingApi.Models;

namespace PersonalBudgetingApi.Services;

public class UserService : IUserService
{
    private readonly PersonalBudgetingDbContext _context;

    public UserService(PersonalBudgetingDbContext context)
    {
        _context = context;
    }

    public async Task<User> RegisterAsync(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<User?> GetByIdAsync(Guid id)
    {
        return await _context.Users.FindAsync(id);
    }

    public async Task<List<User>> GetAllAsync()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null) return false;

        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
        return true;
    }
}
