using System;
using System.Collections.Generic;
using SpeedRun.Models.Interfaces;

namespace SpeedRun.Models
{
    public class Value : IIncludeObject
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public List<string> IncludesNeeded()
        {
            return new List<string>();
        }
    }
}
