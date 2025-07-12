namespace PersonalBudgetingApi.Models;

public class Category
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Type { get; set; }
    public int UserId { get; set; }
    public User? User { get; set; }
    public int TransactionId { get; set; }
    public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}