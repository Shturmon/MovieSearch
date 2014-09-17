using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using DAL.Contracts;

namespace DAL.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> 
        where T : class
    {
        protected MoviesContext Context;
        protected DbSet<T> DbSet;

        public BaseRepository(MoviesContext context)
        {
            Context = context;
            DbSet = context.Set<T>();
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> filter = null,
                                  Func< IQueryable<T>, IOrderedQueryable<T> > orderBy = null,
                                  string includeProperties = "")
        {
            IQueryable<T> query = DbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            return orderBy != null ? orderBy(query).ToList() : query.ToList();
        }

        public T GetById(object id)
        {
            return DbSet.Find(id);
        }

        public virtual void Insert(T entity)
        {
            DbSet.Add(entity);
        }

        public void Delete(object id)
        {
            T entityToDelete = GetById(id);
            Delete(entityToDelete);
        }

        public void Delete(T entityToDelete)
        {
            if (Context.Entry(entityToDelete).State == EntityState.Detached)
            {
                DbSet.Attach(entityToDelete);
            }
            DbSet.Remove(entityToDelete);
        }

        public void Update(T entityToUpdate)
        {
            DbSet.Attach(entityToUpdate);
            Context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public void Save()
        {
            Context.SaveChanges();
        }
    }
}