namespace SavingAccount_BE.Model
{
    public class Card
    {
        public string IdCard {  get; set; }
        public string CardNumber { get; set; }
        public double Balance { get; set; }
        public DateTime DateOpened { get; set; }

        public string? Base64Image { get; set; }

        public string TypeCard {  get; set; }

        public string NameOfCard {  get; set; }

        public string IdHistory { get; set; }

        public History History { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
