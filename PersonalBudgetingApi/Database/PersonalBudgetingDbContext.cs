namespace PersonalBudgetingApi.Data;

public class PersonalBudgetingDbContext(DbContextOptions<PersonalBudgetingDbContext> options) : DbContext(options), DbContext
{
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

            entity.Property(u => u.Name)
                  .IsRequired()
                  .HasMaxLength(100);
        });
    }
}
