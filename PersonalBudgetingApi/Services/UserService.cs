using Microsoft.EntityFrameworkCore;
using PersonalBudgetingApi.Models;
using PersonalBudgetingApi.Utils;
using PersonalBudgetingApi.Services.Interfaces;
using PersonalBudgetingApi.Database;

namespace PersonalBudgetingApi.Services;

public class UserService(PersonalBudgetingDbContext context) : IUserService
{
    private readonly PersonalBudgetingDbContext _context = context;

    public async Task<bool> EmailExistsAsync(string email)
    {
        return await _context.Users.AnyAsync(u => u.Email == email);
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<User> RegisterAsync(string firstName, string lastName, string email, string password, string currency, string language, DateTime dateOfBirth)
    {
        if (await EmailExistsAsync(email))
        {
            throw new Exception("Ushbu email allaqachon ro'yxatdan o'tgan.");
        }

        var salt = PasswordHasher.GenerateSalt();
        var hashedPassword = PasswordHasher.HashPassword(password, salt);

        var user = new User
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            PasswordSalt = salt,
            PasswordHash = hashedPassword,
            Currency = currency,
            PreferredLanguage = language,
            Role = "user",
            IsEmailConfirmed = false,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            IsActive = true,
            DateOfBirth = dateOfBirth,
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return user;
    }
}