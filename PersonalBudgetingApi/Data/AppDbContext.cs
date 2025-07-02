using Microsoft.EntityFrameworkCore;
using PersonalBudgetingApi.Models;

namespace PersonalBudgetingApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
    }
}