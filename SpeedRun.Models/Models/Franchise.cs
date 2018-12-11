using System;
using System.Collections.Generic;

namespace SpeedRun.Models.Models
{
    public class Franchise
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }

        public List<Product.Product> Products { get; set; }
    }
}