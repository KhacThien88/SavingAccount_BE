using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SavingAccount_BE.Model;

namespace SavingAccount_BE.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(t => t.IdUser);
            builder.Property(t => t.CCCD).IsRequired();
            builder.Property(t => t.FullName).IsRequired();
            builder.Property(t => t.Email).IsRequired();
            builder.Property(t => t.BirthDate).IsRequired();
            builder.Property(t => t.AccessFailedCount).IsRequired().HasDefaultValue(0);
            builder.Property(t => t.EmailConfirmed).IsRequired().HasDefaultValue(false);
            builder.Property(t => t.PhoneNumber).IsRequired();
            builder.Property(t => t.PhoneNumberConfirmed).IsRequired().HasDefaultValue(true);
            builder.Property(t => t.PasswordHash).IsRequired();
            builder.Property(t => t.TwoFactorEndable).IsRequired().HasDefaultValue(false);
            builder.Property(t => t.SecurityStampHash).IsRequired().HasDefaultValue(" ");
            builder.Property(t => t.Province).IsRequired();
            builder.Property(t => t.City).IsRequired();
            builder.Property(t => t.LockoutEndable).IsRequired().HasDefaultValue(false);
            builder.Property(t => t.Nation).IsRequired();
        }
    }
}
