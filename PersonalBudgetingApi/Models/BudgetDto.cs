namespace PersonalBudgetingApi.Models;
public class BudgetDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Limit { get; set; }
}