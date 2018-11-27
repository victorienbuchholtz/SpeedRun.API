using SpeedRun.Models;
using SpeedRun.RepositoryGeneric.Interface;
using SpeedRun.ServiceGeneric;
using SpeedRun.Services.Interfaces;

namespace SpeedRun.Services
{
    public class ValueService : ServiceGeneric<Value>, IValueService
    {
        public ValueService(IRepositoryGeneric<Value> repo) : base(repo)
        {
        }

        
    }
}
