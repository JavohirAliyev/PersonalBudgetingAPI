namespace PersonalBudgetingApi.Models;
public class User
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string? LastName { get; set; }   
    public string? FirstName { get; set; } 
    public string? Email { get; set; } 
    public string? PasswordHash { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string? Currency { get; set; }
    public string? PreferredLanguage { get; set; }
    public bool IsEmailConfirmed { get; set; }
    public string? Role { get; set; } = "User";
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    public bool IsActive { get; set; }
}