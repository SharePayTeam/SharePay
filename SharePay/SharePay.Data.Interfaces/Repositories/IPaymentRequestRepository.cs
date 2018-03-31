using SharePay.Entities.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharePay.Data.Interfaces.Repositories
{
    public interface IPaymentRequestRepository : IRepository<PaymentRequest>
    {
        Task<PaymentRequest> GetRequests(int userId);
    }
}
