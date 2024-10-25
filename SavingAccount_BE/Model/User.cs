namespace SavingAccount_BE.Model
{
    public class User
    {
        public string IdUser { get; set; }
        public string CCCD { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public int AccessFailedCount { get; set; }
        public bool EmailConfirmed { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public bool TwoFactorEndable { get; set; }
        public string SecurityStampHash { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string Nation { get; set; }
        public bool LockoutEndable { get; set; }
        public string? Base64Image { get; set; }
        public string? Friend { get; set; }

        public ICollection<UserSavingAccount> UserSavingAccounts { get; set; }

        public ICollection<UserCard> UserCards { get; set; }
        public ICollection<User> Relatives { get; set; }

        public ICollection<UserNotification> userNotifications { get; set; }
    }
}
