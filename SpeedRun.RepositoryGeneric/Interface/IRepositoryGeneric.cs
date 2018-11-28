using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SpeedRun.RepositoryGeneric.Interface
{
    public interface IRepositoryGeneric <T> where T : class
    {
        List<T> GetAll(Expression<Func<T, bool>> predicate);
        T Get(Expression<Func<T, bool>> predicate = null);
        T Add(T obj);
        T Update(T obj);
        void Delete(T obj);
    }
}