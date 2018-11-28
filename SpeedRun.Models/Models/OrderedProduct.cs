using System;

namespace SpeedRun.Models.Models
{
    public class OrderedProduct
    {
        public Guid Id { get; set; }
        public double Price { get; set; }
        public double Taxes { get; set; }
        public string CdKey { get; set; }

        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
