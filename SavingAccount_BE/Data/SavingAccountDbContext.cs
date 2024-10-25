using Microsoft.EntityFrameworkCore;
using SavingAccount_BE.Configuration;
using SavingAccount_BE.Model;
using SavingAccount_BE.Seeders;

namespace SavingAccount_BE.Data
{
    public class SavingAccountDbContext : DbContext
    {
        public SavingAccountDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new HistoryConfiguration());
            modelBuilder.ApplyConfiguration(new CardConfiguration());
            modelBuilder.ApplyConfiguration(new SavingAccountConfiguration());
            modelBuilder.ApplyConfiguration(new NotificationConfiguration());
            
            modelBuilder.Entity<Card>().HasOne(c => c.History).WithMany(h => h.Cards).HasForeignKey(c => c.IdHistory);
            modelBuilder.Entity<SavingAccount>().HasOne(sa => sa.History).WithMany(h => h.SavingAccounts).HasForeignKey(sa => sa.IdHistory);
            modelBuilder.Entity<SavingAccount>().HasKey(c => c.IdSavingAccount);
            modelBuilder.Entity<User>().HasOne(u => u.Card).WithMany(c => c.Users).HasForeignKey(u => u.IdCard);
            modelBuilder.Entity<User>().HasOne(u => u.SavingAccount).WithMany(sa => sa.Users).HasForeignKey(u => u.IdSavingAccount);
            modelBuilder.Entity<User>().HasOne(u => u.Notification).WithMany(n => n.Users).HasForeignKey(u => u.IdNotification);
            modelBuilder.Entity<User>().HasOne(u => u.Users).WithMany(u => u.Relatives).HasForeignKey(u => u.Friend).HasPrincipalKey(u => u.Email);

            modelBuilder.SeedHistory();
            modelBuilder.SeedSavingAccount();
            modelBuilder.SeedCard();
            modelBuilder.SeedNotification();
            modelBuilder.SeedUser();
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Card> Cards { get; set; }

        public DbSet<History> Histories { get; set; }
        public DbSet<Notification> Notifications{ get; set; }
        public DbSet<SavingAccount> SavingAccounts { get; set; }

    }
}
