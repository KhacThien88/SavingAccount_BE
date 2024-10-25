using Microsoft.EntityFrameworkCore;
using SavingAccount_BE.Model;

namespace SavingAccount_BE.Seeders
{
    public static class NotificationDatabaseSeeder
    {
        public static void SeedNotification(this ModelBuilder modelBuilder) {
            modelBuilder.Entity<Notification>().HasData(
                new Notification() { IdNotification = "1" , Content = "Day la VKT"},
                new Notification() { IdNotification = "2", Content = "Day la LPT" }
                );
        }
    }
}
