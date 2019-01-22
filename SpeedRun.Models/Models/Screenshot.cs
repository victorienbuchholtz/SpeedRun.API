using System;
using SpeedRun.Models.Models.Product;

namespace SpeedRun.Models.Models
{
    public class Screenshot
    {
        private Guid guid;
        private string url;
        private Product.Product product;

        public Screenshot()
        {
        }

        public Screenshot(Guid guid, string url, Product.Product product)
        {
            this.guid = guid;
            this.url = url;
            this.product = product;
        }

        public Guid Id { get; set; }
        public string ScreenshotUrl { get; set; }

        public Product.Product Product { get; set; }
    }
}
