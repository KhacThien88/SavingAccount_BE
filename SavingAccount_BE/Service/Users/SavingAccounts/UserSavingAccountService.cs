﻿using SavingAccount_BE.Data;
using SavingAccount_BE.Model;

namespace SavingAccount_BE.Service.Users.SavingAccounts
{
    public class UserSavingAccountService : IUserSavingAccountService
    {
        private readonly SavingAccountDbContext _dbContext;

        public UserSavingAccountService(SavingAccountDbContext dbcontext) { 
            
            _dbContext = dbcontext;
        
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
