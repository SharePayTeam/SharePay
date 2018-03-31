using SharePay.Data.Interfaces;
using SharePay.Data.Interfaces.Repositories;
using SharePay.Entities.Data.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SharePay.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        protected readonly DbContext dbContext;

        public Repository(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        
        public TEntity Get(int id)
        {
            return dbContext.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            return filter != null ? dbContext.Set<TEntity>().Where(filter) : dbContext.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            if (entity is IEntityCreateTrackable)
            {
                (entity as IEntityCreateTrackable).CreatedDate = DateTime.UtcNow;
            }
            
            dbContext.Set<TEntity>().Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            this.dbContext.Set<TEntity>().AddRange(entities);
        }

        public void Update(TEntity entity)
        {
            if (entity is IEntityEditTrackable)
            {
                (entity as IEntityEditTrackable).ModifiedDate = DateTime.UtcNow;
            }

            dbContext.Entry<TEntity>(entity).State = EntityState.Modified;
        }

        public void Remove(TEntity entity)
        {
            dbContext.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            dbContext.Set<TEntity>().RemoveRange(entities);
        }

        public void Attach(TEntity entity)
        {
            dbContext.Set<TEntity>().Attach(entity);
        }

        public void Detach(TEntity entity)
        {
            dbContext.Entry<TEntity>(entity).State = EntityState.Detached;
        }
        
    }
}
