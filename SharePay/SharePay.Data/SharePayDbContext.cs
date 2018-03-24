using SharePay.Entities;
using System.Data.Entity;

namespace SharePay.Data
{
    public class SharePayDbContext : DbContext
    {
        public DbSet<IdentityUser> Users { get; set; }

        public SharePayDbContext()
            : base("name=SharePayDBConnectionString") 
        {

        }
    }
}
