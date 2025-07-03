using PersonalBudgetingApi.Models;

namespace PersonalBudgetingApi.Services.Interfaces;

public interface IUserService
{
    User Register(UserRegisterDto dto);
    User Login(UserLoginDto dto);
    User GetProfile(Guid userId);
    User UpdateProfile(Guid userId, UserUpdateDto dto);
}