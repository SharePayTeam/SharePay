using SharePay.Entities;
using SharePay.Entities.Data;
using System.Data.Entity;

namespace SharePay.Data
{
    public class SharePayDbContext : DbContext
    {
        public SharePayDbContext()
            : base("name=SharePayDBConnectionString") 
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<BankCard> BankCards { get; set; }
        public DbSet<Currency> Currencys { get; set; }
        public DbSet<PaymentRequest> PaymentRequests { get; set; }
        public DbSet<PaymentEntry> PaymentEntrys { get; set; }
    }
}
