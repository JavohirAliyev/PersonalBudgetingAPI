namespace PersonalBudgetingApi.DTO;

public class BudgetDto
{
    public required string Name { get; set; }
    public decimal Limit { get; set; }
}