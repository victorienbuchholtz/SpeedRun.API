using System;

namespace SpeedRun.Models.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public double Price { get; set; }
        public double Taxes { get; set; }
        public int DeliveryTime { get; set; }
        public bool Active { get; set; }
        public int Inventory { get; set; }
    }
}
