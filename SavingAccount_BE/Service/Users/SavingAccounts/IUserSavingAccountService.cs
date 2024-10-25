using SavingAccount_BE.Model;

namespace SavingAccount_BE.Service.Users.SavingAccounts
{
    public interface IUserSavingAccountService
    {
        List<SavingAccount> GetListSavingAccounts(string id);
    }
}
