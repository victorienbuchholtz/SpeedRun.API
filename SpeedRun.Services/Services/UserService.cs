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

        public User GetByIDGitHub(string idGitHub)
        {
            User user = Get(x => x.IDGitHub.Equals(idGitHub));
            if (user != null)
                return user;
            return new User();
        }
    }
}
