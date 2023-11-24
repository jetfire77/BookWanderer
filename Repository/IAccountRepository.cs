using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Tanuj.BookStore.Models;

namespace Tanuj.BookStore.Repository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> CreateUserAsync(SignUpUserModel userModel);

        Task<SignInResult> PasswordSignInAsync(SignInModel SignInModel);

        Task SignOutAsync();

        Task<IdentityResult> changePasswordAsync(ChangePasswordModel model);

        Task<IdentityResult> ConfirmEmailAsync(string uid, string token);

        Task GenerateEmailConfirmationAsync(ApplicationUser user);

        Task<ApplicationUser> GetUserByEmailAsync(string email);

        Task GenerateForgotPasswordTokenAsync(ApplicationUser user);

        Task<IdentityResult> ResetPasswordAsync(ResetPasswordModel model);



    }

}