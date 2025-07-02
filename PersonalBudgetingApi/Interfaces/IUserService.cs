using PersonalBudgetingApi.Models;

namespace PersonalBudgetingApi.Interfaces;

public interface IUserService
{
    Task<User> RegisterAsync(User user);
    Task<User?> GetByIdAsync(Guid id);
    Task<List<User>> GetAllAsync();
    Task<bool> DeleteAsync(Guid id);
}