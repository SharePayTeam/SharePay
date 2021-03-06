﻿using SharePay.Entities.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharePay.Data.Interfaces.Repositories
{
    public interface IBalanceEntryRepository : IRepository<BalanceEntry>
    {
        Task<Balance> GetBalance(int userId);
    }
}
