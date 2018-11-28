using System;
using Microsoft.EntityFrameworkCore;
using SpeedRun.RepositoryGeneric.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SpeedRun.RepositoryGeneric.Repository
{
    public class RepositoryGeneric<T> : IRepositoryGeneric<T> where T : class
    {
        protected DbContext context;

        public RepositoryGeneric(DbContext dbContextType)
        {
            context = dbContextType;
        }

        public List<T> GetAll(Expression<Func<T, bool>> predicate = null)
        {
            var dbSet = context.Set<T>();
            if (predicate == null) return dbSet.AsQueryable().ToList();
            var query = dbSet.Where(predicate).AsQueryable();
            return query.ToList();
        }

        public T Get(Expression<Func<T, bool>> predicate = null)
        {
            var dbSet = context.Set<T>();
            if (predicate == null) return dbSet.AsQueryable().FirstOrDefault();
            var query = dbSet.Where(predicate).AsQueryable().FirstOrDefault();
            return query;
        }

        public T Add(T obj)
        {
            context.Attach(obj);
            context.Set<T>().Add(obj);
            context.SaveChanges();
            return obj;
        }

        public T Update(T obj)
        {
            context.Attach(obj);
            context.Set<T>().Update(obj);
            context.SaveChanges();
            return obj;
        }

        public void Delete(T obj)
        {
            context.Attach(obj);
            context.Set<T>().Remove(obj);
            context.SaveChanges();
        }
    }
}
