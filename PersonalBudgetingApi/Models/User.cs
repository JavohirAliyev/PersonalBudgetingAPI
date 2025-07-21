namespace PersonalBudgetingApi.Models;

public class User
{
    public int Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public required DateTime DateOfBirth { get; set; }
    public string? Currency { get; set; }
    public string? PreferredLanguage { get; set; }
    public bool IsEmailConfirmed { get; set; }
    public string Role { get; set; } = "user";
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public bool IsActive { get; set; }
    public required string PasswordSalt { get; set; }
    public required string PasswordHash { get; set; }

    public ICollection<Category> Categories { get; set; } = [];
    public ICollection<Transaction> Transactions { get; set; } = [];
    public ICollection<Budget> Budgets { get; set; } = [];
    public ICollection<Subsccription> Subsccriptions { get; set; } = [];
}