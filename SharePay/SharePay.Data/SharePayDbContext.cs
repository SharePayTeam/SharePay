using System.Data.Entity;

namespace SharePay.Data
{
    public class SharePayDbContext : DbContext, ISharePayDbContext
    {
        public SharePayDbContext()
            : base("name=SharePayDBConnectionString") 
        {
        }
    }
}
