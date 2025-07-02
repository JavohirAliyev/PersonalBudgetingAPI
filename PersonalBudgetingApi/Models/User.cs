namespace PersonalBudgetingApi.Models;

public class User
{
    public int Id { get; set; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string PasswordHash { get; set; } = default!;
    public DateTime DateOfBirth { get; set; }
    public string Currency { get; set; } = "USD";
    public string PreferredLanguage { get; set; } = "en";
    public bool IsEmailConfirmed { get; set; } = false;
    public string Role { get; set; } = "User"; // Default role is User, can be Admin or other roles in the future
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public bool IsActive { get; set; } = true;
}
