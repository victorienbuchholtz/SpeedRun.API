using System;
using System.Collections.Generic;
using SpeedRun.Models.Interfaces;

namespace SpeedRun.Models.Models
{
    public class Order : IIncludeObject
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }

        public User User { get; set; }

        public List<string> IncludesNeeded()
        {
            return new List<string>();
        }
    }
}
