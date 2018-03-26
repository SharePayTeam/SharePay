using SharePay.Data.Migrations;
using SharePay.Entities.Data;
using System.Data.Entity;

namespace SharePay.Data
{
    public class SharePayDbContext : DbContext, ISharePayDbContext
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
        public DbSet<Balance> Balances { get; set; }
        public DbSet<BalanceEntry> BalanceEntries { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SharePayDbContext, Configuration>());

            base.OnModelCreating(modelBuilder);
        }
    }
}
