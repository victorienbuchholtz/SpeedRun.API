using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace SpeedRun.Models.Models
{
    public class User : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ZipCode { get; set; }
        public string Address { get; set; }
        public string City { get; set; }

        public string AvatarUrl { get; set; }

        public List<DeliveryAddress> DeliveryAddresses { get; set; }
        public List<Order> Orders { get; set; }
    }
}
