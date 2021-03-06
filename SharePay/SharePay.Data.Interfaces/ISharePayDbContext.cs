﻿using SharePay.Entities.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharePay.Data.Interfaces
{
    public interface ISharePayDbContext : IDisposable
    {
        DbSet<User> Users { get; set; }

        DbSet<BankCard> BankCards { get; set; }

        DbSet<Currency> Currencys { get; set; }

        DbSet<PaymentRequest> PaymentRequests { get; set; }

        DbSet<PaymentEntry> PaymentEntrys { get; set; }

        DbSet<Balance> Balances { get; set; }

        DbSet<BalanceEntry> BalanceEntries { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        Task<int> SaveChangesAsync();
    }
}
