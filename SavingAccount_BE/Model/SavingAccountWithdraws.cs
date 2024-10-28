namespace SavingAccount_BE.Model
{
    public class SavingAccountWithdraws
    {
        public string IdUser { get; set; }
        public string NameOfSavingAccount { get; set; }

        public string IdCard { get; set; }
        public DateTime DateWithdraws { get; set; }

        public double Amount { get; set; }

        public string password { get; set; }
    }
}
