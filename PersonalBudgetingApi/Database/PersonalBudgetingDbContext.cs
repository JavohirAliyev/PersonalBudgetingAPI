using Microsoft.EntityFrameworkCore;
using PersonalBudgetingApi.Models;

namespace PersonalBudgetingApi.Data;

public class PersonalBudgetingDbContext : DbContext
{
    public PersonalBudgetingDbContext(DbContextOptions<PersonalBudgetingDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasIndex(u => u.Email).IsUnique();
            entity.Property(u => u.Email)
                  .IsRequired()
                  .HasMaxLength(255);

            entity.Property(u => u.FirstName)
                  .IsRequired()
                  .HasMaxLength(100);

            entity.Property(u => u.LastName)
                  .IsRequired()
                  .HasMaxLength(100);
        });
    }
}