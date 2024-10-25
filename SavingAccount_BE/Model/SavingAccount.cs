namespace SavingAccount_BE.Model
{
    public class SavingAccount
    {
        public string IdSavingAccount { get; set; }
        public string NameOfSavingAccount { get; set; }

        public string Term {  get; set; }

        public string IdHistory { get; set; }

        public double Balance { get; set; }

        public History History { get; set; }

        public ICollection<User> Users { get; set; }

        public DateTime DateOpened { get; set; }
    }
}
