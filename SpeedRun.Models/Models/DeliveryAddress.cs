using System;
using System.Collections.Generic;
using SpeedRun.Models.Interfaces;

namespace SpeedRun.Models.Models
{
    public class DeliveryAddress : IIncludeObject
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
        public List<Order> Orders { get; set; }
        public List<string> IncludesNeeded()
        {
            return new List<string>();
        }
    }
}
