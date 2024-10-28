using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SavingAccount_BE.Data;
using SavingAccount_BE.Model;

namespace SavingAccount_BE.Service.Users.SavingAccounts
{
    public class UserSavingAccountService : IUserSavingAccountService
    {
        private readonly SavingAccountDbContext _dbContext;
        private readonly ILogger<UserSavingAccountService> _logger;
        public readonly UserManager<ApplicationUser> _userManager;
        public UserSavingAccountService(SavingAccountDbContext dbcontext, ILogger<UserSavingAccountService> logger, UserManager<ApplicationUser> userManager)
        {

            _dbContext = dbcontext;
            _logger = logger;
            _userManager = userManager;
        }

        public async Task<bool> AddSavingAccountAsync(AddSavingAccountModel addSavingAccountModel)
        {
            var user = _dbContext.ApplicationUsers.FirstOrDefault(u => u.Id == addSavingAccountModel.IdUser);
            if (user == null || !await _userManager.CheckPasswordAsync(user, addSavingAccountModel.Password))
            {
                _logger.LogError("Failed to find user or password does not match.");
                return false;
            }
            var card = _dbContext.Cards.FirstOrDefault(c => c.IdCard == addSavingAccountModel.IdCard);
            if (card == null && card.Balance < addSavingAccountModel.Amount)
            {
                _logger.LogError("Failed to find card or insufficient balance.");
                return false;
            }
            else
            {
                card.Balance -= addSavingAccountModel.Amount;
                var IdGenerate = Guid.NewGuid().ToString();
                
                _dbContext.Histories.Add(new History()
                {
                    IdHistory = IdGenerate,
                    Change = -(addSavingAccountModel.Amount),
                    DateTransfer = DateTime.UtcNow,
                    Note = "Open Saving Account"
                    
                });
                _dbContext.CardHistories.Add(new CardHistory() { 
                    IdHistory = IdGenerate,
                    IdCard = addSavingAccountModel.IdCard,
                });
            }

            _dbContext.SavingAccounts.Add(new SavingAccount()
            {
                IdSavingAccount = addSavingAccountModel.IdSavingAccount,
                Balance = addSavingAccountModel.Amount,
                DateOpened = DateTime.Now,
                Deposits = addSavingAccountModel.Amount,
                Term = addSavingAccountModel.Term,
                NameOfSavingAccount = addSavingAccountModel.SavingAccountName,
                Withdraw = 0,
            });
            _dbContext.UserSavingAccounts.Add(new UserSavingAccount()
            {
                IdSavingAccount = addSavingAccountModel.IdSavingAccount,
                IdUser = user.Id,
            });
            var IdGenerate_sa = Guid.NewGuid().ToString();
            _dbContext.Histories.Add(new History()
            {
                IdHistory = IdGenerate_sa ,
                Change = addSavingAccountModel.Amount,
                DateTransfer = DateTime.UtcNow,
                Note = "Open Saving Account"
            });
            _dbContext.SavingAccountsHistory.Add(new SavingAccountHistory()
            {
                IdHistory = IdGenerate_sa ,
                IdSavingAccount = addSavingAccountModel.IdSavingAccount
                
            });

            var result = _dbContext.SaveChanges();
            return result > 0;

        }

        public List<SavingAccount> GetListSavingAccounts(string id)
        {
            var user = _dbContext.Users.Where(u => u.IdUser == id);
            
            bool checkValidSavingAccounts = _dbContext.UserSavingAccounts
                .Where(usa => user.Select(u => u.IdUser).Contains(usa.IdUser))
                .Any();

            if (user == null && checkValidSavingAccounts) { 
                return new List<SavingAccount>();
            }

            var listSavingAccountIds = _dbContext.UserSavingAccounts
                .Where(usa => user.Select(u => u.IdUser).Contains(usa.IdUser))
                .Select(u => u.IdSavingAccount);
            var listSavingAccount = _dbContext.SavingAccounts
                .Where(sa => listSavingAccountIds.Contains(sa.IdSavingAccount))
                .ToList();

            foreach (var savingAccount in listSavingAccount)
            {
                var savingAccountHistories = _dbContext.SavingAccountsHistory
                    .Where(sah => sah.IdSavingAccount == savingAccount.IdSavingAccount)
                    .Select(sah => sah.History);

                double totalDeposits = 0;
                double totalWithdraws = 0;

                foreach (var history in savingAccountHistories)
                {
                    if (history.Change > 0)
                    {
                        totalDeposits += history.Change;
                    }
                    else if (history.Change < 0)
                    {
                        totalWithdraws += Math.Abs(history.Change);
                    }
                }
                savingAccount.Deposits = totalDeposits;
                savingAccount.Withdraw = totalWithdraws;
            }
            return listSavingAccount;
        }

       
    }
}
