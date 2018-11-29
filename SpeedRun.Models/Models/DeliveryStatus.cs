using System;
using System.Collections.Generic;

namespace SpeedRun.Models.Models
{
    public class DeliveryStatus
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<Order> Orders { get; set; }
    }
}
