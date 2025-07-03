using Microsoft.AspNetCore.Mvc;
using PersonalBudgetingApi.Models;
using PersonalBudgetingApi.Services.Interfaces;

namespace PersonalBudgetingApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("register")]
    public ActionResult<User> Register(UserRegisterDto dto)
    {
        try
        {
            var user = _userService.Register(dto);
            return Ok(user); // Or Created(...) if you prefer
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("login")]
    public ActionResult<User> Login(UserLoginDto dto)
    {
        try
        {
            var user = _userService.Login(dto);
            return Ok(user);
        }
        catch (Exception ex)
        {
            return Unauthorized(ex.Message);
        }
    }

    [HttpGet("{id}")]
    public ActionResult<User> GetProfile(Guid id)
    {
        try
        {
            var user = _userService.GetProfile(id);
            return Ok(user);
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPut("{id}")]
    public ActionResult<User> UpdateProfile(Guid id, UserUpdateDto dto)
    {
        try
        {
            var user = _userService.UpdateProfile(id, dto);
            return Ok(user);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}