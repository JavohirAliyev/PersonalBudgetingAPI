namespace PersonalBudgetingApi.DTO;

public class CategoryUpdateDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
}
