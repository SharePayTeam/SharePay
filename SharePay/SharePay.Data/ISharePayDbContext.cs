using SharePay.Entities.Data;
using System;
using System.Data.Entity;
using System.Threading.Tasks;

namespace SharePay.Data
{
    public interface ISharePayDbContext : IDisposable
    {
        DbSet<User> Users { get; set; }

        DbSet<BankCard> BankCards { get; set; }

        DbSet<Currency> Currencys { get; set; }

        DbSet<PaymentRequest> PaymentRequests { get; set; }

        DbSet<PaymentEntry> PaymentEntrys { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        Task<int> SaveChangesAsync();
    }
}
