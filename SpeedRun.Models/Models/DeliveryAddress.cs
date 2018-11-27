using System;
using System.Collections.Generic;

namespace SpeedRun.Models.Models
{
    public class DeliveryAddress
    {
        public Guid Id { get; set; }
        public bool DefaultAddress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ZipCode { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }

        public User User { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
