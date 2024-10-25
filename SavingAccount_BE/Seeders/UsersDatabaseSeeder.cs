using Microsoft.EntityFrameworkCore;
using SavingAccount_BE.Model;

namespace SavingAccount_BE.Seeders
{
    public static class UserDatabaseSeeder
    {
        public static void SeedUser(this ModelBuilder modelBuilder)
        {
            // Seed dữ liệu cho User
           modelBuilder.Entity<User>().HasData(
                new User() 
                    { 
                        IdUser = "1", 
                        FullName = "John Doe", 
                        Email = "john@example.com", 
                        PhoneNumber = "1234567890", 
                        CCCD = "001", 
                        PasswordHash = "password123",
                        City = "Hà Nội",
                        Province = "Hà Nội",
                        Nation = "Việt Nam",
                        SecurityStampHash = "abc123",
                        BirthDate = new DateTime(1990, 1, 1),
                        AccessFailedCount = 0,
                        EmailConfirmed = true,
                        PhoneNumberConfirmed = true,
                        TwoFactorEndable = false,
                        LockoutEndable = false
                    },
                    new User() 
                    { 
                        IdUser = "2", 
                        FullName = "Jane Smith", 
                        Email = "jane@example.com", 
                        PhoneNumber = "0987654321", 
                        CCCD = "002", 
                        PasswordHash = "password456",
                        City = "Hồ Chí Minh",
                        Province = "Hồ Chí Minh",
                        Nation = "Việt Nam",
                        SecurityStampHash = "xyz456",
                        BirthDate = new DateTime(1992, 5, 20),
                        AccessFailedCount = 0,
                        EmailConfirmed = true,
                        PhoneNumberConfirmed = true,
                        TwoFactorEndable = false,
                        LockoutEndable = false
                    }
                );


            modelBuilder.Entity<UserSavingAccount>().HasData(
                new UserSavingAccount() { Id = 1, IdUser = "1", IdSavingAccount = "1" },
                new UserSavingAccount() { Id = 2, IdUser = "2", IdSavingAccount = "2" }
            );

            modelBuilder.Entity<UserCard>().HasData(
                new UserCard() { Id = 1, IdUser = "1", IdCard = "1" },
                new UserCard() { Id = 2, IdUser = "2", IdCard = "2" },
                new UserCard() { Id = 3, IdUser = "1", IdCard = "3" }
            );

            modelBuilder.Entity<UserNotification>().HasData(
                new UserNotification { Id = 1, IdUser = "1", IdNotification = "1" },
                new UserNotification { Id = 2, IdUser = "2", IdNotification = "2" }
);

        }
    }
}
