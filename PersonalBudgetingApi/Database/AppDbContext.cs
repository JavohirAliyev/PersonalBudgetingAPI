using Microsoft.EntityFrameworkCore;
using PersonalBudgetingApi.Models;

namespace PersonalBudgetingApi.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        // Optionally override OnModelCreating for custom mapping
        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     base.OnModelCreating(modelBuilder);
        // }
    }
}
