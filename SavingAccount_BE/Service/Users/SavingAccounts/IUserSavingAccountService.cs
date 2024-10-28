using SavingAccount_BE.Model;
using System.Diagnostics.Eventing.Reader;

namespace SavingAccount_BE.Service.Users.SavingAccounts
{
    public interface IUserSavingAccountService
    {
        Task<List<SavingAccount>> GetListSavingAccounts(string id);
        Task<bool> AddSavingAccountAsync(AddSavingAccountModel addSavingAccountModel);

        Task<bool> updateSavingAccountBalance(string id);
    }
}
