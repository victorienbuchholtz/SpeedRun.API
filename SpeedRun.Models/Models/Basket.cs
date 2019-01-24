﻿using SpeedRun.Models.Interfaces;
using System;
using System.Collections.Generic;

namespace SpeedRun.Models.Models
{
    public class Basket : IIncludeObject
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }

        public Guid ProductId { get; set; }
        public Product.Product Product { get; set; }

        public Boolean Archived { get; set; }

        public List<string> IncludesNeeded()
        {
            return new List<string>();
        }
    }
}
