using System;
using System.Collections.Generic;
using SpeedRun.Models.Models.Product;

namespace SpeedRun.Models.Models
{
    public class Company
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string UrlLogo { get; set; }
        public string Description { get; set; }

        // Many to many
        public List<ProductPublisher> Published { get; set; }
        public List<ProductDeveloper> Developed { get; set; }
    }
}