using System.Collections.Generic;
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

        public List<T> GetAll()
        {
            return Repo.GetAll(null);
        }

        public T Add(T obj)
        {
            return Repo.Add(obj);
        }
    }
}
