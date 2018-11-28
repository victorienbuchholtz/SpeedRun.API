using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using SpeedRun.RepositoryGeneric.Interface;
using SpeedRun.ServiceGeneric.Interface;

namespace SpeedRun.ServiceGeneric
{
    public class ServiceGeneric<T> : IServiceGeneric<T> where T : class
    {
        protected IRepositoryGeneric<T> Repo;

        public ServiceGeneric(IRepositoryGeneric<T> repo)
        {
            this.Repo = repo;
        }

        public List<T> GetAll(Expression<Func<T, bool>> predicate = null)
        {
            return Repo.GetAll(predicate);
        }

        public T Get(Expression<Func<T, bool>> predicate = null)
        {
            return Repo.Get(predicate);
        }

        public T Add(T obj)
        {
            return Repo.Add(obj);
        }

        public T Update(T obj)
        {
            return Repo.Update(obj);
        }

        public void Delete(T obj)
        {
            Repo.Delete(obj);
        }
    }
}
