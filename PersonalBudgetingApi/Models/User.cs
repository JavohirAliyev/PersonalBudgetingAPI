using System.ComponentModel.DataAnnotations;

namespace PersonalBudgetingApi.Models;

public class User
{
    public Guid Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }

    [EmailAddress]
    public required string Email { get; set; }

    public required string PasswordHash { get; set; }
    public byte[]? PasswordSalt { get; set; }

    public DateTime DateOfBirth { get; set; }
    public required string Currency { get; set; }
    public required string PreferredLanguage { get; set; }
    public bool IsEmailConfirmed { get; set; }
    public required string Role { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public bool IsActive { get; set; }
}
