﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace SpeedRun.Models.Models
{
    public class Role : IdentityRole<Guid>
    {
        public string Description { get; set; }
    }
}
