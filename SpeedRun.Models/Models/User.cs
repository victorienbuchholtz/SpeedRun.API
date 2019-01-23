using SpeedRun.Models.Interfaces;
using System;
using System.Collections.Generic;

namespace SpeedRun.Models.Models
{
    public class User : IIncludeObject
    {
        public Guid Id { get; set; }
        public string PhoneNumber { get; set; }
        public string Mail { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ZipCode { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string IDGitHub { get; set; }
        public string AvatarUrl { get; set; }

        public List<DeliveryAddress> DeliveryAddresses { get; set; }
        public List<Order> Orders { get; set; }
        public List<Basket> Baskets { get; set; }
        public List<string> IncludesNeeded()
        {
            return new List<string>();
        }
    }
}
