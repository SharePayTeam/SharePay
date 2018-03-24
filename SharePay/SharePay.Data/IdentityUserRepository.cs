using Microsoft.AspNet.Identity;
using SharePay.Entities;
using System.Data.Entity;
using System.Threading.Tasks;

namespace SharePay.Data
{
    public class IdentityUserRepository : IUserStore<IdentityUser, int>
    {
        private readonly ISharePayDbContext dbContext;

        public IdentityUserRepository(ISharePayDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task CreateAsync(IdentityUser user)
        {
            dbContext.Set<IdentityUser>().Add(user);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(IdentityUser user)
        {
            dbContext.Set<IdentityUser>().Remove(user);
            await dbContext.SaveChangesAsync();
        }

        public async Task<IdentityUser> FindByIdAsync(int userId)
        {
            var result = await dbContext.Set<IdentityUser>()
                .FindAsync(userId);

            return result;
        }

        public async Task<IdentityUser> FindByNameAsync(string userName)
        {
            var result = await dbContext.Set<IdentityUser>()
                .FirstOrDefaultAsync(x => x.UserName == userName);

            return result;
        }

        public async Task UpdateAsync(IdentityUser user)
        {
            var result = await FindByIdAsync(user.Id);
            if (result != null)
            {
                await dbContext.SaveChangesAsync();
            }
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }
    }
}
