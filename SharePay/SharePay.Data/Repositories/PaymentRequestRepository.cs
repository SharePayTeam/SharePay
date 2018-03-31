using SharePay.Data.Interfaces;
using SharePay.Data.Interfaces.Repositories;
using SharePay.Entities.Data;
using System.Data.Entity;
using System.Threading.Tasks;

namespace SharePay.Data.Repositories
{
    public class PaymentRequestRepository : Repository<PaymentRequest>, IPaymentRequestRepository
    {
        public PaymentRequestRepository(ISharePayDbContext dbContext) : base((SharePayDbContext)dbContext)
        {
        }

        public Task<IEnumerable<PaymentRequest>> GetUserPaymentRequests(int userId)
        {
            return null;
        }

        public async Task<PaymentRequest> GetActiveUserPaymentRequests(int userId)
        {
            var result = await dbContext.Set<PaymentRequest>()
                .Where(x => x.UserId == userId && !x.IsClosed && !x.IsDeleted).FirstOrDefaultAsync();

            return result;
        }

    }
}
