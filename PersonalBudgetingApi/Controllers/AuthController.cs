using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using PersonalBudgetingApi.Interfaces;
using PersonalBudgetingApi.Utils;
using PersonalBudgetingApi.Services;
using PersonalBudgetingApi.DTO;

namespace PersonalBudgetingApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly TokenService _tokenService;

    public AuthController(IUserService userService, TokenService tokenService)
    {
        _userService = userService;
        _tokenService = tokenService;
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
                dto.PreferredLanguage,
                dto.DateOfBirth 
            );

            return Ok(new
            {
                message = "user registered succesfully",
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
            return Unauthorized(new { message = "Invalid email or password" });

        var isValid = PasswordHasher.VerifyPassword(dto.Password, user.PasswordSalt!, user.PasswordHash!);

        if (!isValid)
            return Unauthorized(new { message = "Invalid email or password" });

        var token = _tokenService.CreateToken(user);

        return Ok(new
        {
            message = "logged in successfully",
            token
        });
    }

    [HttpGet("me")]
    [Authorize]
    public IActionResult Me()
    {
        var id = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
        var email = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
        var name = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
        var role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

        return Ok(new
        {
            isAuthenticated = true,
            id,
            email,
            name,
            role
        });
    }
}
