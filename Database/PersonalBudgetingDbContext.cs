namespace PersonalBudgetingApi.Data
{
    public class PersonalBudgetingDbContext : DbContext
    {
        public PersonalBudgetingDbContext(DbContextOptions<PersonalBudgetingDbContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}
