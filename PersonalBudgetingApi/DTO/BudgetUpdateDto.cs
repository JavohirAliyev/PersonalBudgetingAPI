namespace PersonalBudgetingApi.DTO;

public class BudgetUpdateDto
{
    public string Name { get; set; } = string.Empty;
    public decimal Limit { get; set; }
}