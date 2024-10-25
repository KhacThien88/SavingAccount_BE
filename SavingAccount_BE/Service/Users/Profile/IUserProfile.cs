using SavingAccount_BE.Model;

namespace SavingAccount_BE.Service.Users.Profile
{
    public interface IUserProfile
    {
        User GetProfile(string id);

        bool updateProfile(string id, UserDTO updatedUser);
    }
}
