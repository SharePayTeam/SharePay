using Microsoft.AspNet.Identity;
using SharePay.Entities.Data;
using SharePay.Services.Interfaces;

namespace SharePay.Services
{
    public class ApplicationUserManager : UserManager<User, int>, IApplicationUserManager
    {
        public ApplicationUserManager(IUserStore<User, int> store) 
            : base(store)
        {
            UserValidator = new UserValidator<User, int>(this)
            {
                AllowOnlyAlphanumericUserNames = true,
                RequireUniqueEmail = true
            };

            // Configure validation logic for passwords
            PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = false,
                RequireUppercase = false,
            };

            // Configure user lockout defaults
            UserLockoutEnabledByDefault = false;
        }
    }
}
