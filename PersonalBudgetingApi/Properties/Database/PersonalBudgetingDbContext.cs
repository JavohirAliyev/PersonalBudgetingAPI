using Microsoft.EntityFrameworkCore;
using PersonalBudgetingApi.Models;

namespace PersonalBudgetingApi.Data;

public class PersonalBudgetingDbContext : DbContext
{
    public PersonalBudgetingDbContext(DbContextOptions<PersonalBudgetingDbContext> options)
        : base(options) { }

    public DbSet<User> Users => Set<User>();
}
