namespace PersonalBudgetingApi.Models;

public class LoginDto
{
    public required string Email { get; set; } = default!;
    public required string Password { get; set; } = default!;
}