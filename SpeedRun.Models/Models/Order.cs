using System;
using System.Collections.Generic;

namespace SpeedRun.Models.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }

        public User User { get; set; }
        public DeliveryStatus DeliveryStatus { get; set; }
        public DeliveryAddress DeliveryAddress { get; set; }
        public List<OrderedProduct> OrderedProducts { get; set; }
    }
}
