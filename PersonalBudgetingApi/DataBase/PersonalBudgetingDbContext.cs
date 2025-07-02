using Microsoft.EntityFrameworkCore;
using PersonalBudgeting.Models;

public class PersonalBudgetingDbContext : DbContext
{
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite("Data Source=app.db");
}