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
        public DbSet<Subsccription> Subsccriptions { get; set; }

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

            modelBuilder.Entity<Subsccription>(entity =>
            {
                entity.HasIndex(s => new { s.UserId, s.Name }).IsUnique();

                entity.Property(s => s.Name)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(s => s.Amount)
                      .IsRequired()
                      .HasColumnType("decimal(18,2)");

                entity.Property(s => s.StartDate)
                      .IsRequired();

                entity.Property(s => s.Frequency)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.HasOne(s => s.User)
                    .WithMany(u => u.Subsccriptions)
                    .HasForeignKey(s => s.UserId);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasIndex(c => new { c.UserId, c.Name }).IsUnique();

                entity.Property(c => c.Name)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.HasOne(c => c.User)
                .WithMany(u => u.Categories)
                .HasForeignKey(c => c.UserId);
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.HasIndex(t => t.CategoryId);

                entity.Property(t => t.Amount)
                      .IsRequired()
                      .HasColumnType("decimal(18,2)");

                entity.Property(t => t.Date)
                      .IsRequired();

                entity.Property(t => t.Description)
                      .HasMaxLength(500);

                entity.HasOne(t => t.User)
                    .WithMany(u => u.Transactions)
                    .HasForeignKey(t => t.UserId)
                    .OnDelete(DeleteBehavior.ClientNoAction);

                entity.HasOne(t => t.Category)
                    .WithMany(c => c.Transactions)
                    .HasForeignKey(t => t.CategoryId)
                    .OnDelete(DeleteBehavior.ClientNoAction);
            });

            modelBuilder.Entity<Budget>(entity =>
            {
                entity.HasIndex(b => new { b.UserId, b.Name }).IsUnique();

                entity.Property(b => b.Name)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(b => b.Limit)
                      .IsRequired()
                      .HasColumnType("decimal(18,2)");

                entity.HasOne(b => b.User)
                    .WithMany(u => u.Budgets)
                    .HasForeignKey(b => b.UserId);
            });

            modelBuilder.Entity<User>()
                .HasData(
                    new User { Id = 1, Email = "johndoe@gmail.com", FirstName = "John", LastName = "Doe", DateOfBirth = new DateTime(1990, 1, 1), PasswordHash = "hashedpassword1", PasswordSalt = "salt1" },
                    new User { Id = 2, Email = "janesmith@gmail.com", FirstName = "Jane", LastName = "Smith", DateOfBirth = new DateTime(1992, 2, 2), PasswordHash = "hashedpassword2", PasswordSalt = "salt2" }
                );

            modelBuilder.Entity<Subsccription>()
            .HasData(
                new Subsccription { Id = 1, Name = "Netflix", Amount = 15.99m, StartDate = new DateTime(2023, 1, 1), Frequency = "Monthly", UserId = 1 },
                new Subsccription { Id = 2, Name = "Spotify", Amount = 9.99m, StartDate = new DateTime(2023, 2, 1), Frequency = "Monthly", UserId = 1 },
                new Subsccription { Id = 3, Name = "Amazon Prime", Amount = 12.99m, StartDate = new DateTime(2023, 3, 1), Frequency = "Monthly", UserId = 2 },
                new Subsccription { Id = 4, Name = "Hulu", Amount = 11.99m, StartDate = new DateTime(2023, 4, 1), Frequency = "Monthly", UserId = 2 }
            );

            modelBuilder.Entity<Category>()
                .HasData(
                    new Category { Id = 1, Name = "Groceries", Type = "Expense", UserId = 1 },
                    new Category { Id = 2, Name = "Utilities", Type = "Expense", UserId = 1 },
                    new Category { Id = 3, Name = "Salary", Type = "Income", UserId = 1 },
                    new Category { Id = 4, Name = "Entertainment", Type = "Expense", UserId = 2 },
                    new Category { Id = 5, Name = "Investments", Type = "Income", UserId = 2 }
                );

            modelBuilder.Entity<Transaction>()
                .HasData(
                    new Transaction { Id = 1, Amount = 50.00m, Date = new DateTime(2023, 10, 1), Description = "Grocery shopping", CategoryId = 1, UserId = 1 },
                    new Transaction { Id = 2, Amount = 100.00m, Date = new DateTime(2023, 10, 2), Description = "Electricity bill", CategoryId = 2, UserId = 1 },
                    new Transaction { Id = 3, Amount = 2000.00m, Date = new DateTime(2023, 10, 3), Description = "Monthly salary", CategoryId = 3, UserId = 1 },
                    new Transaction { Id = 4, Amount = 30.00m, Date = new DateTime(2023, 10, 4), Description = "Movie night", CategoryId = 4, UserId = 2 },
                    new Transaction { Id = 5, Amount = 500.00m, Date = new DateTime(2023, 10, 5), Description = "Stock investment", CategoryId = 5, UserId = 2 }
                );

            modelBuilder.Entity<Budget>()
                .HasData(
                    new Budget { Id = 1, Name = "Monthly Budget", Limit = 1500.00m, UserId = 1 },
                    new Budget { Id = 2, Name = "Annual Savings", Limit = 5000.00m, UserId = 2 }
                );
        }
    }

}
