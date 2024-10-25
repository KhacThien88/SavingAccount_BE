using SavingAccount_BE.Data;
using SavingAccount_BE.Model;

namespace SavingAccount_BE.Service.Users.Histories
{
    public class UserHistory : IUserHistory
    {
        private readonly SavingAccountDbContext _dbContext;

        public UserHistory(SavingAccountDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<History> GetHistory(string id)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Id == id);

            if (user == null || string.IsNullOrEmpty(user.IdCard) || string.IsNullOrEmpty(user.IdSavingAccount))
            {
                return new List<History>();
            }

            var cards = _dbContext.Cards.Where(c => c.IdCard == user.IdCard).ToList();
            var savingAccounts = _dbContext.SavingAccounts.Where(sa => sa.IdSavingAccount == user.IdSavingAccount).ToList();
            var cardHistoryIds = cards.Select(c => c.IdHistory).Distinct().ToList();
            var savingAccountHistoryIds = savingAccounts.Select(c => c.IdHistory).Distinct().ToList();
            var combinedHistoryIds = cardHistoryIds.Concat(savingAccountHistoryIds).Distinct().ToList();
            var histories = _dbContext.Histories.Where(h => combinedHistoryIds.Contains(h.IdHistory)).ToList();
            return histories;
        }
    }
}
