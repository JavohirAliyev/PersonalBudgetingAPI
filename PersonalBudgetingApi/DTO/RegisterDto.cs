namespace PersonalBudgetingApi.DTO;

public class RegisterDto
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
    public string Currency { get; set; } = "usd";
    public string PreferredLanguage { get; set; } = "en"; 
    public DateTime DateOfBirth { get; set; }
}