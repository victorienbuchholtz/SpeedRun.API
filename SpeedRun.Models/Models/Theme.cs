using System;
using System.Collections.Generic;

namespace SpeedRun.Models.Models
{
    public class Theme
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public List<Product> Products { get; set; }
    }
}