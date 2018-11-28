using SpeedRun.Models.Models;
using SpeedRun.RepositoryGeneric.Interface;
using SpeedRun.ServiceGeneric;
using SpeedRun.Services.Interfaces;

namespace SpeedRun.Services.Services
{
    public class UserService : ServiceGeneric<User>, IUserService
    {
        public UserService(IRepositoryGeneric<User> repo) : base(repo)
        {
        }
    }
}
