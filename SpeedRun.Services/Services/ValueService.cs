using SpeedRun.ServiceGeneric;
using System;
using SpeedRun.Models;
using SpeedRun.RepositoryGeneric.Interface;
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
