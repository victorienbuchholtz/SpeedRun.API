using System;

namespace SpeedRun.Models.Models
{
    public class Screenshot
    {
        public Guid Id { get; set; }
        public string ScreenshotUrl { get; set; }

        public Product.Product Product { get; set; }
    }
}
