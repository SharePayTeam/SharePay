using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using SharePay.Entities.Data;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SharePay.Common.Services
{
    public class ApplicationSignInManager : SignInManager<User, int>
    {
        public ApplicationSignInManager(ApplicationUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        public override async Task<ClaimsIdentity> CreateUserIdentityAsync(User user)
        {
            var identity = await UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);

            // add claims here
            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));

            return identity;
        }
    }
}
