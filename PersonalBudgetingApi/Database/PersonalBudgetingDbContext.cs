using Microsoft.EntityFrameworkCore;
using PersonalBudgetingApi.Models;

namespace PersonalBudgetingApi.Database
{
    public class PersonalBudgetingDbContext(DbContextOptions<PersonalBudgetingDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Budget> Budgets { get; set; }

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

}
