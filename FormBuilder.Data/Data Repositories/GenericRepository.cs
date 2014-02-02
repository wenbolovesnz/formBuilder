using System;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using FormBuilder.Data.Contracts;

namespace FormBuilder.Data
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class 
    {
        internal DbSet<TEntity> dbSet;
        internal FormBuilderContext context;

        public GenericRepository(FormBuilderContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        /// <summary>
        /// Get all entities with support of filtering and sorting at DB level reducing load on Web Server
        /// </summary>
        /// <param name="filter">Enable caller to provide any expression like student => student.LastName == "Smith"</param>
        /// <param name="orderBy">Enable caller to provide any expression like q => q.OrderBy(s => s.LastName)</param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        public virtual IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            // If user has provided any filter expression then apply it
            if (filter != null)
            {
                query = query.Where(filter);
            }

            // Enable eager loading of provided entities
            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            // Order the collection if user has provided any order expression
            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public virtual TEntity GetByID(object id)
        {
            return dbSet.Find(id);
        }

        public virtual void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Delete(object id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public void Detach(TEntity entity)
        {
            DbEntityEntry entry = this.context.Entry(entity);
            entry.State = EntityState.Detached;
        }
    }
}
