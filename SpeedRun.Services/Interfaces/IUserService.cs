using SpeedRun.Models.Models;
using SpeedRun.ServiceGeneric.Interface;

namespace SpeedRun.Services.Interfaces
{
    public interface IUserService : IServiceGeneric<User>
    {
        User GetByIDGitHub(string idGitHub);
    }
}
