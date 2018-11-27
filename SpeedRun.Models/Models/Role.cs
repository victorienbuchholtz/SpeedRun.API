using Microsoft.AspNetCore.Identity;
using System;

namespace SpeedRun.Models.Models
{
    public class Role : IdentityRole<Guid>
    {
        public string Description { get; set; }
    }
}
