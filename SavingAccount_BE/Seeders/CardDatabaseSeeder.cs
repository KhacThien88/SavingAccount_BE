using Microsoft.EntityFrameworkCore;
using SavingAccount_BE.Model;

namespace SavingAccount_BE.Seeders
{
    public static class CardDatabaseSeeder
    {
        public static void SeedCard(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Card>().HasData(
                new Card() { IdCard = "1", CardNumber = "000001", Balance = 200000, DateOpened = new DateTime(2022, 10, 10), TypeCard = "Tin dung", NameOfCard = "The tin dung", IdHistory = "1" },
                new Card() { IdCard = "2", CardNumber = "000002", Balance = 500000, DateOpened = new DateTime(2021, 10, 10), TypeCard = "Tin dung", NameOfCard = "The tin dung", IdHistory = "3" }
            );
        }
    }
}
