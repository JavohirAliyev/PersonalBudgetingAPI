using PersonalBudgetingApi.Models;
using PersonalBudgetingApi.Services.Interfaces;
using PersonalBudgetingApi.Database;
using BCrypt.Net;

namespace PersonalBudgetingApi.Services;

public class UserService : IUserService
{
    private readonly PersonalBudgetingDbContext _context;

    public UserService(PersonalBudgetingDbContext context)
    {
        _context = context;
    }
    public User Register(UserRegisterDto dto)
    {
        if (_context.Users.Any(u => u.Email == dto.Email))
            throw new Exception("Email is already registered.");

        var user = new User
        {
            Id = Guid.NewGuid(),
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password)
        };

        _context.Users.Add(user);
        _context.SaveChanges();

        return user;
    }

    public User Login(UserLoginDto dto)
    {
        var user = _context.Users.FirstOrDefault(u => u.Email == dto.Email);

        if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
            throw new Exception("Invalid email or password.");

        return user;
    }

    public User GetProfile(Guid userId)
    {
        var user = _context.Users.Find(userId);

        if (user == null)
            throw new Exception("User not found.");

        return user;
    }

    public User UpdateProfile(Guid userId, UserUpdateDto dto)
    {
        var user = _context.Users.Find(userId);

        if (user == null)
            throw new Exception("User not found.");

        user.FirstName = dto.FirstName;
        user.LastName = dto.LastName;
        user.Email = dto.Email;

        _context.SaveChanges();

        return user;
    }
}
