namespace PersonalBudgetingApi.Models;

public class User
{
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? PasswordHash { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Currency { get; set; } = "usd";
    public string PreferredLanguage { get; set; } = "en";
    public bool IsEmailConfirmed { get; set; }
    public string Role { get; set; } = "User";
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public bool IsActive { get; set; }
}