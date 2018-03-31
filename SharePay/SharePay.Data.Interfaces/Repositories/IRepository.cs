using SharePay.Entities.Data.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SharePay.Data.Interfaces.Repositories
{
    public interface IRepository<TEntity> where TEntity : class, IEntity
    {
        TEntity Get(int id);

        IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null);

        void Add(TEntity entity);

        void AddRange(IEnumerable<TEntity> entities);

        void Update(TEntity entity);

        void Remove(TEntity entity);

        void RemoveRange(IEnumerable<TEntity> entities);

        void Attach(TEntity entity);

        void Detach(TEntity entity);
    }
}
