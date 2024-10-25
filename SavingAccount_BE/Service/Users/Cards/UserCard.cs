using SavingAccount_BE.Data;
using SavingAccount_BE.Model;

namespace SavingAccount_BE.Service.Users.Cards
{
    public class UserCard : IUserCard
    {
        private readonly SavingAccountDbContext _dbContext;

        public UserCard(SavingAccountDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Card> GetListCards(string userId)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Id == userId);
            if (user == null || string.IsNullOrEmpty(user.IdCard))
            {
                return new List<Card>();
            }
            var cards = _dbContext.Cards.Where(c => c.IdCard == user.IdCard).ToList();
            return cards;
        }
    }
}
