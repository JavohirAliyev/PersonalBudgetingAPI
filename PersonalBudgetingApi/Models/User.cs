namespace PersonalBudgeting.Models;

public class User
{
    public Guid Id { get; set; }
    public required string? FirstName { get; set; }
    public required string? LastName { get; set; }
    public string? Email { get; set; }
    public string? PasswordHash { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string? Currency { get; set; }
    public string? PreferredLanguage { get; set; }
    public bool IsEmailConfirmed { get; set; }
    public string? Role { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public bool IsActive { get; set; }
}