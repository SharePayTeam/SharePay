using Microsoft.AspNet.Identity;
using SharePay.Entities.Data;
using System.Data.Entity;
using System.Threading.Tasks;

namespace SharePay.Data
{
    public class UserStore : IUserStore<User, int>, IUserPasswordStore<User, int>, IUserEmailStore<User, int>
    {
        private readonly ISharePayDbContext dbContext;

        public UserStore(ISharePayDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task CreateAsync(User user)
        {
            dbContext.Set<User>().Add(user);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(User user)
        {
            dbContext.Set<User>().Remove(user);
            await dbContext.SaveChangesAsync();
        }

        public async Task<User> FindByIdAsync(int userId)
        {
            var result = await dbContext.Set<User>()
                .FindAsync(userId);

            return result;
        }

        public async Task<User> FindByNameAsync(string userName)
        {
            var result = await dbContext.Set<User>()
                .FirstOrDefaultAsync(x => x.UserName == userName);

            return result;
        }

        public async Task UpdateAsync(User user)
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

        public async Task SetPasswordHashAsync(User user, string passwordHash)
        {
            user.Password = passwordHash;
            await UpdateAsync(user);
        }

        public Task<string> GetPasswordHashAsync(User user)
        {
            return Task.FromResult(user.Password);
        }

        public Task<bool> HasPasswordAsync(User user)
        {
            return Task.FromResult(!string.IsNullOrEmpty(user.Password));
        }

        public async Task SetEmailAsync(User user, string email)
        {
            user.Email = email;
            await UpdateAsync(user);
        }

        public Task<string> GetEmailAsync(User user)
        {
            return Task.FromResult(user.Email);
        }

        public Task<bool> GetEmailConfirmedAsync(User user)
        {
            throw new System.NotImplementedException();
        }

        public Task SetEmailConfirmedAsync(User user, bool confirmed)
        {
            throw new System.NotImplementedException();
        }

        public async Task<User> FindByEmailAsync(string email)
        {
            var result = await dbContext.Set<User>()
                .FirstOrDefaultAsync(x => x.Email == email);

            return result;
        }
    }
}
