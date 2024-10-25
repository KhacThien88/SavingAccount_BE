using Microsoft.EntityFrameworkCore;
using SavingAccount_BE.Model;

namespace SavingAccount_BE.Seeders
{
    public static class SavingAccountDatabaseSeeder
    {
        public static void SeedSavingAccount(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SavingAccount>().HasData(
                new SavingAccount() { IdSavingAccount = "1", DateOpened = new DateTime(2022,08,08),Balance = 300000,NameOfSavingAccount="VKT",IdHistory="2",Term="3 months"},
                new SavingAccount() { IdSavingAccount = "2", DateOpened = new DateTime(2022,09,09), Balance = 500000, NameOfSavingAccount = "LPT", IdHistory = "4", Term = "6 months" }
                );
        }
    }
}
