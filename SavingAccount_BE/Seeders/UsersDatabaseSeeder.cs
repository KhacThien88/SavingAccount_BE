using Microsoft.EntityFrameworkCore;
using SavingAccount_BE.Model;
using System.Runtime.CompilerServices;

namespace SavingAccount_BE.Seeders
{
    public static class UsersDatabaseSeeder
    {
        public static void SeedUser(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User() { Id = "1",IdCard="1",IdSavingAccount="1",IdNotification="1",FullName = "Vo Khac Thien",CCCD="215913523" , Email = "KTeightop1512@gmail.com", PhoneNumber = "0905647832", PasswordHash = "$2y$10$KBvSdRCHLCo6DHHq5kSiiemIOFbKVAQMVeZr5ulfAPiWpQtSeAYD2", Province = "Binh Dinh", City = "Quy Nhon", Nation = "Viet Nam" },
                new User() { Id = "2", IdCard = "2", IdSavingAccount="2", IdNotification = "2", FullName = "Le Phuc Thuan", CCCD = "215913524", Email = "lephucthuan8@gmail.com", PhoneNumber = "113", PasswordHash = "$2y$10$KBvSdRCHLCo6DHHq5kSiiemIOFbKVAQMVeZr5ulfAPiWpQtSeAYD2", Province = "Quang Ngai", City = "Quang Ngai", Nation = "Viet Nam" }
            );
        }
    }
}
