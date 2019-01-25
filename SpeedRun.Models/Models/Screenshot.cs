using System;
using System.Collections.Generic;
using SpeedRun.Models.Interfaces;

namespace SpeedRun.Models.Models
{
    public class Screenshot : IIncludeObject
    {
        public Guid Id { get; set; }
        public string ScreenshotUrl { get; set; }
        public Product Product { get; set; }

        public Screenshot()
        {
        }

        public Screenshot(Guid guid, string url, Product product)
        {
            this.Id = guid;
            this.ScreenshotUrl = url;
            this.Product = product;
        }

        public List<string> IncludesNeeded()
        {
            return new List<string> { "product" };
        }
    }
}
