namespace PersonalBudgetingApi.Models;

public class User
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string PasswordHash { get; set; } = default!;
    public string? ProfilePictureUrl { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string Currency { get; set; } = "USD";
    public string PreferredLanguage { get; set; } = "en";
    public bool IsEmailConfirmed { get; set; } = false;
    public string Role { get; set; } = "user";
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    public bool IsActive { get; set; } = true;
}
