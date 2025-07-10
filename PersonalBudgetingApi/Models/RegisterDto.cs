namespace PersonalBudgetingApi.Models;

public class RegisterDto
{
    public required string FirstName { get; set; } = default!;
    public required string LastName { get; set; } = default!;
    public required string Email { get; set; } = default!;
    public required string Password { get; set; } = default!;
    public required string Currency { get; set; } = "usd";
    public required string PreferredLanguage { get; set; } = "en";
}