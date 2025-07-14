using PersonalBudgetingApi.Models;

namespace PersonalBudgetingApi.Services.Interfaces;

public interface IUserService
{
    Task<bool> EmailExistsAsync(string email);
    Task<User?> GetByEmailAsync(string email);
    Task<User> RegisterAsync(string firstName, string lastName, string email, string password, string currency, string language, DateTime dateOfBirth);
}