using System;
using System.Collections.Generic;
using System.Text;

namespace SpeedRun.Models.Models
{
    public class Video
    {
        public Guid Id { get; set; }
        public string VideoUrl { get; set; }

        public Product Product { get; set; }
    }
}
