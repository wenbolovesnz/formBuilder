using System;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;


namespace FormBuilder.Data.Data_Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class 
    {
        protected DbSet<T> DbSet { get; set; }
        protected FormBuilderContext Context { get; set; }

        public GenericRepository(FormBuilderContext context)
        {
            if(context == null)
            {
                throw new ArgumentException(); 
            }
            this.Context = context;
            this.DbSet = context.Set<T>();
        }

        public IQueryable<T> GetAll()
        {
            return this.DbSet;
        }

        public T GetById(int id)
        {
            return this.DbSet.Find(id);
        }

        public void Add(T entity)
        {
            DbEntityEntry entry = this.Context.Entry(entity);
            if(entry.State != EntityState.Detached)
            {
                entry.State = EntityState.Added;
            }
            else
            {
                this.DbSet.Add(entity);
            }
        }

        public void Update(T entity)
        {
            DbEntityEntry entry = this.Context.Entry(entity);
            if(entry.State == EntityState.Detached)
            {
                this.DbSet.Attach(entity);
            }
            
            entry.State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            DbEntityEntry entry = this.Context.Entry(entity);

            if (entry.State != EntityState.Deleted)
            {
                entry.State = EntityState.Deleted;               ;
            }
            else
            {
                this.DbSet.Attach(entity);
                this.DbSet.Remove(entity);
            }
        }

        public void Delete(int id)
        {
            T entityToDelete = this.GetById(id);
            this.Delete(entityToDelete);
        }

        public void Detach(T entity)
        {
            DbEntityEntry entry = this.Context.Entry(entity);
            entry.State = EntityState.Detached;
        }
    }
}
