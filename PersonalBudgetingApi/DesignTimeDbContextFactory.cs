using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using PersonalBudgetingApi.Data;

namespace PersonalBudgetingApi;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<PersonalBudgetingDbContext>
{
    public PersonalBudgetingDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<PersonalBudgetingDbContext>();
        optionsBuilder.UseSqlite("Data Source=personalbudgeting.db");

        return new PersonalBudgetingDbContext(optionsBuilder.Options);
    }
}