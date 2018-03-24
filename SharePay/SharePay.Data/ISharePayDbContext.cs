using System;
using System.Data.Entity;
using System.Threading.Tasks;

namespace SharePay.Data
{
    public interface ISharePayDbContext : IDisposable
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        Task<int> SaveChangesAsync();
    }
}
