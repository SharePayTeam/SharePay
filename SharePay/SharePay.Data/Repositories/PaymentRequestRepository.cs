using SharePay.Data.Interfaces;
using SharePay.Data.Interfaces.Repositories;
using SharePay.Entities.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        
    }
}
