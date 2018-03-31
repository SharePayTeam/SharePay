using SharePay.Data.Interfaces;
using SharePay.Data.Interfaces.Repositories;
using SharePay.Entities.Data;
using System.Data.Entity;
using System.Threading.Tasks;

namespace SharePay.Data.Repositories
{
    public class BalanceEntryRepository : Repository<BalanceEntry>, IBalanceEntryRepository
    {
        public BalanceEntryRepository(ISharePayDbContext dbContext) : base((SharePayDbContext) dbContext)
        {
        }

        public async Task<Balance> GetBalance(int userId)
        {
            var result = await dbContext.Set<Balance>()
                .FirstOrDefaultAsync(x => x.UserId == userId);

            return result;
        }
    }
}
