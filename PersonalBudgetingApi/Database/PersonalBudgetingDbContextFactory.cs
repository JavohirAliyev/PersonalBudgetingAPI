using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;
using PersonalBudgetingApi.Data;

namespace PersonalBudgetingApi.Data
{
    public class PersonalBudgetingDbContextFactory : IDesignTimeDbContextFactory<PersonalBudgetingDbContext>
    {
        public PersonalBudgetingDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) 
                .AddJsonFile("appsettings.json")             
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<PersonalBudgetingDbContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            optionsBuilder.UseSqlite(connectionString);

            return new PersonalBudgetingDbContext(optionsBuilder.Options);
        }
    }
}