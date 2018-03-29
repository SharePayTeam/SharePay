using SharePay.Entities.Data;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SharePay.Common.Interfaces
{
    public interface IApplicationSignInManager
    {
        Task<ClaimsIdentity> CreateUserIdentityAsync(User user);
    }
}
