using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace SavingAccount_BE.Data
{
    public class SavingAccountDbContextFactory : IDesignTimeDbContextFactory<SavingAccountDbContext>
    {
        public SavingAccountDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configurationRoot = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configurationRoot.GetConnectionString("UsersDatabase");
            var optionBuilder = new DbContextOptionsBuilder<SavingAccountDbContext>();
            optionBuilder.UseSqlServer(connectionString);
            return new SavingAccountDbContext(optionBuilder.Options);
        }
    }
}
