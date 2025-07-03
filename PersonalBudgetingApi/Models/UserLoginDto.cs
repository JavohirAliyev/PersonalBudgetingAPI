namespace PersonalBudgetingApi.Models;

public class UserLoginDto
{
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
}
