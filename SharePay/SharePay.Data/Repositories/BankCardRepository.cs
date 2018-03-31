using SharePay.Data.Interfaces;
using SharePay.Data.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharePay.Data.Repositories
{
    public class BankCardRepository : IBankCardRepository
    {
        private readonly ISharePayDbContext dbContext;

        public BankCardRepository(ISharePayDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
