using Microsoft.EntityFrameworkCore;
using SpeedRun.Models.Models;
using SpeedRun.RepositoryGeneric.Repository;

namespace SpeedRun.Repository.Repostories
{
    public class SpeedRunRepository<T> : RepositoryGeneric<T> where T : class
    {
        public SpeedRunRepository(DbContext context) : base(context)
        {
        }
    }
}
