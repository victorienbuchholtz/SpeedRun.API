using System.Collections.Generic;

namespace SpeedRun.RepositoryGeneric.Interface
{
    public interface IRepositoryGeneric <T> where T : class
    {
        List<T> GetAll();
        T Add(T obj);
    }
}