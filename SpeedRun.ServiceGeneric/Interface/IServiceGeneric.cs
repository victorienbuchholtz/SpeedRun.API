using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SpeedRun.ServiceGeneric.Interface
{
    public interface IServiceGeneric<T> where T : class
    {
        List<T> GetAll(Expression<Func<T, bool>> predicate = null);
        T Get(Expression<Func<T, bool>> predicate = null);
        T Add(T obj);
    }
}