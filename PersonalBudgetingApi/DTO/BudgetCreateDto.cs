namespace PersonalBudgetingApi.DTO;

public class BudgetCreateDto
{
    public string Name { get; set; } = string.Empty;
    public decimal Limit { get; set; }
}
