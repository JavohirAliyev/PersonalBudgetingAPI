namespace PersonalBudgetingApi.Models
{
    public class Subsccription
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required decimal Amount { get; set; }
        public required DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public required string Frequency { get; set; }
        public int UserId { get; set; }
        public bool IsActive { get; set; }
        public User? User { get; set; }
    }
}