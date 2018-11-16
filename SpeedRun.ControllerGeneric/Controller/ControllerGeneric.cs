using Microsoft.AspNetCore.Mvc;

namespace SpeedRun.ControllerGeneric
{
    public class ControllerGeneric<T> : ControllerBase where T : class
    {
    }
}
