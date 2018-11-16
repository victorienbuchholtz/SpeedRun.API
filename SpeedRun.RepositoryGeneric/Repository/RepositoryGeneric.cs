using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SpeedRun.RepositoryGeneric.Interface;

namespace SpeedRun.RepositoryGeneric.Repository
{
    public class RepositoryGeneric<T> : IRepositoryGeneric<T> where T : class
    {
        protected DbContext context;

        public RepositoryGeneric(DbContext dbContextType)
        {
            context = dbContextType;
        }

        public List<T> GetAll()
        {
            var dbSet = context.Set<T>();
            var query = dbSet.AsQueryable();
            return query.ToList();
        }

        public T Add(T obj)
        {
            context.Attach(obj);
            context.Set<T>().Add(obj);
            context.SaveChanges();
            return obj;
        }
    }
}
