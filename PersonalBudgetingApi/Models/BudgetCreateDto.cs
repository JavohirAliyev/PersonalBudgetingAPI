namespace PersonalBudgetingApi.Models;

public class BudgetCreateDto
{
    public string Name { get; set; } = string.Empty;
    public decimal Limit { get; set; }
}
