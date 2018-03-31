using SharePay.Data.Interfaces;
using SharePay.Data.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharePay.Data.Repositories
{
    public class BalanceEntryRepository : IBalanceEntryRepository
    {
        private readonly ISharePayDbContext dbContext;

        public BalanceEntryRepository(ISharePayDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
