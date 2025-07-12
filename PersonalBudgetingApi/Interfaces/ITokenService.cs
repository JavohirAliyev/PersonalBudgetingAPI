using PersonalBudgetingApi.Models;

namespace PersonalBudgetingApi.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}