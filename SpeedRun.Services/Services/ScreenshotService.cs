using SpeedRun.Models.Models;
using SpeedRun.RepositoryGeneric.Interface;
using SpeedRun.ServiceGeneric;
using SpeedRun.Services.Interfaces;

namespace SpeedRun.Services.Services
{
    public class ScreenshotService : ServiceGeneric<Screenshot>, IScreenshotService
    {
        public ScreenshotService(IRepositoryGeneric<Screenshot> repo) : base(repo)
        {
        }
    }
}
