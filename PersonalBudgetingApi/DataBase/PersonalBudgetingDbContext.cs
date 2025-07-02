using Microsoft.EntityFrameworkCore;
using PersonalBudgetingApi.Models;

public class PersonalBudgetingDbContext : DbContext
{
    public PersonalBudgetingDbContext(DbContextOptions<PersonalBudgetingDbContext> options) : base(options) {}

    public DbSet<User> Users { get; set; } = default!;
}
