using Microsoft.EntityFrameworkCore;
using SpeedRun.Models.Models;
using SpeedRun.RepositoryGeneric.Repository;

namespace SpeedRun.Repository.Repositories
{
    public class SpeedRunRepository<T> : RepositoryGeneric<T> where T : class
    {
        public SpeedRunRepository(SpeedRunDbContext context) : base(context)
        {
        }
    }
}
