namespace SavingAccount_BE.Model
{
    public class User
    {
        public string Id { get; set; }
        public string CCCD { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime BirthDate { get; }

        public int AccessFailedCount {  get; set; }

        public bool EmailConfirmed { get; set; }

        public bool PhoneNumberConfirmed { get; set; }

        public string PasswordHash { get; set; }

        public bool TwoFactorEndable {  get; set; }

        public string SecurityStampHash { get; set; }

        public string Province { get; set; }

        public string City { get; set; }

        public string Nation { get; set; }

        public bool LockoutEndable { get; set; }

        public string? IdNotification { get; set; }

        public string? Base64Image { get; set; }

        public string? Friend { get; set; }

        public string? IdSavingAccount { get; set; }

        public string? IdCard { get; set; } 

        public Card Card { get; set; }

        public SavingAccount SavingAccount { get; set; }

        public Notification Notification { get; set; }

        public User Users { get; set; }

        public ICollection<User> Relatives{  get; set; }

    }
}
