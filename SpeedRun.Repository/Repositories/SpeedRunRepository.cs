using Microsoft.EntityFrameworkCore;
using SpeedRun.Models.Interfaces;
using SpeedRun.Models.Models;
using SpeedRun.RepositoryGeneric.Repository;

namespace SpeedRun.Repository.Repositories
{
    public class SpeedRunRepository<T> : RepositoryGeneric<T> where T : class, IIncludeObject, new()
    {
        public SpeedRunRepository(SpeedRunDbContext context) : base(context)
        {
        }
    }
}
