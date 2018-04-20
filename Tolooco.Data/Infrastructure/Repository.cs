using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Tolooco.Data.DatabaseContext;

namespace Tolooco.Data.Infrastructure
{
    public abstract class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        #region Field
        private FirstDb dbContext;

        private readonly IDbSet<TEntity> dbSet;

        protected IDbFactory<FirstDb> dbFactory
        {
            get;
            private set;
        }
        #endregion

        #region Ctor
        protected Repository(IDbFactory<FirstDb> dbFactory)
        {
            this.dbFactory = dbFactory;
            dbSet = DbContext.Set<TEntity>();
        }

        public FirstDb DbContext
        {
            get { return dbContext ?? (dbContext = dbFactory.Init()); }
        }

        #endregion

        #region Implementation
        public virtual void Delete(object id)
        {
            var entity = GetById(id);
            if (entity == null) throw new ArgumentException("entity");
            dbSet.Remove(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            dbSet.Remove(entity);
        }

        public virtual void Delete(Expression<Func<TEntity, bool>> where)
        {
            IEnumerable<TEntity> objects = dbSet.Where(where).AsEnumerable();
            foreach (TEntity obj in objects) dbSet.Remove(obj);
        }

        public virtual TEntity Get(Expression<Func<TEntity, bool>> where)
        {
            return dbSet.Where(where).FirstOrDefault();
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return dbSet.AsEnumerable();
        }

        public virtual async Task<List<TEntity>> GetAllAsync()
        {
            return await dbSet.ToListAsync();
        }

        public virtual async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> where)
        {
            return await dbSet.Where(where).FirstOrDefaultAsync();
        }

        public virtual TEntity GetById(object Id)
        {
            return dbSet.Find(Id);
        }

        public virtual IEnumerable<TEntity> GetMany(Expression<Func<TEntity, bool>> where)
        {
            return dbSet.Where(where).ToList();
        }

        public virtual async Task<List<TEntity>> GetManyAsync(Expression<Func<TEntity, bool>> where)
        {
            return await dbSet.Where(where).ToListAsync();
        }

        public virtual void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            if (entity == null) throw new ArgumentException("entity");
            dbSet.Attach(entity);
            dbContext.Entry(entity).State = EntityState.Modified;
        }
        #endregion
    }
}
