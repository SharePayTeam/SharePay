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
    public class BalanceRepository : Repository<Balance>, IBalanceRepository
    {
        public BalanceRepository(ISharePayDbContext dbContext) : base((SharePayDbContext)dbContext)
        {
        }
    }
}
