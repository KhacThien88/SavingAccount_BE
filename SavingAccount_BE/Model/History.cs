    namespace SavingAccount_BE.Model
    {
        public class History
        {
            public string IdHistory {  get; set; }
            public double Change { get; set; }

            public DateTime DateTransfer { get; set; }

            public string Note { get; set; }

            public ICollection<Card> Cards { get; set; }
        
            public ICollection<SavingAccount> SavingAccounts { get; set; }

        }
    }
