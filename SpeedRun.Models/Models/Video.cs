using System;

namespace SpeedRun.Models.Models
{
    public class Video
    {
        public Guid Id { get; set; }
        public string VideoUrl { get; set; }

        public Product.Product Product { get; set; }
    }
}
