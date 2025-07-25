namespace PersonalBudgetingApi.Models;

public class Budget
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public decimal Limit { get; set; }

    public int UserId { get; set; }
    public User? User { get; set; }
}