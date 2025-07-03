namespace PersonalBudgetingApi.Models;

public class User
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string PasswordHash { get; set; } = default!;
    public DateOnly DateOfBirth { get; set; }
    public string Currency { get; set; } = "USD";
    public string PreferredLanguage { get; set; } = "en";
    public bool IsEmailConfirmed { get; set; } = false;
    public string Role { get; set; } = "User";
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public bool IsActive { get; set; } = true;
}
