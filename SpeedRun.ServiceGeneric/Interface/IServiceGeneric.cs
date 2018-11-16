using System.Collections.Generic;

namespace SpeedRun.ServiceGeneric.Interface
{
    public interface IServiceGeneric<T> where T : class
    {
        List<T> GetAll();
        T Add(T obj);

    }
}