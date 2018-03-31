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
    public class BankCardRepository : Repository<BankCard>, IBankCardRepository
    {
        public BankCardRepository(ISharePayDbContext dbContext) : base((SharePayDbContext)dbContext)
        {
        }
    }
}
