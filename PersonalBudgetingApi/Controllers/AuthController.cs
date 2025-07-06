using Microsoft.AspNetCore.Mvc;
using PersonalBudgetingApi.Interfaces;
using PersonalBudgetingApi.Models;
using PersonalBudgetingApi.Utils;

namespace PersonalBudgetingApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IUserService _userService;

    public AuthController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterDto dto)
    {
        try
        {
            dto.FirstName = dto.FirstName.Trim();
            dto.LastName = dto.LastName.Trim();
            dto.Email = dto.Email.Trim().ToLower();
            dto.Password = dto.Password.Trim();
            dto.Currency = dto.Currency.Trim().ToUpper();
            dto.PreferredLanguage = dto.PreferredLanguage.Trim().ToLower();

            var user = await _userService.RegisterAsync(
                dto.FirstName,
                dto.LastName,
                dto.Email,
                dto.Password,
                dto.Currency,
                dto.PreferredLanguage
            );

            return Ok(new
            {
                message = "Foydalanuvchi ro'yxatdan o'tkazildi.",
                user = new { user.Id, user.Email }
            });

        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto dto)
    {
        var user = await _userService.GetByEmailAsync(dto.Email.Trim().ToLower());

        if (user == null)
            return Unauthorized(new { message = "Email yoki parol noto‘g‘ri." });

        var isValid = PasswordHasher.VerifyPassword(dto.Password, user.PasswordSalt!, user.PasswordHash!);

        if (!isValid)
            return Unauthorized(new { message = "Email yoki parol noto‘g‘ri." });

        return Ok(new
        {
            message = "Tizimga muvaffaqiyatli kirildi.",
            user = new
            {
                user.Id,
                user.FirstName,
                user.Email,
                user.Role
            }
        });
    }
}
