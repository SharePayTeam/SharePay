using SharePay.Data.Interfaces;
using SharePay.Data.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharePay.Data.Repositories
{
    public class PaymentEntryRepository : IPaymentEntryRepository
    {
        private readonly ISharePayDbContext dbContext;

        public PaymentEntryRepository(ISharePayDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
