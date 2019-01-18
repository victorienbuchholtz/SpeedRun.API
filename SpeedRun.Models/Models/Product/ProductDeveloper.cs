﻿using System;

namespace SpeedRun.Models.Models.Product
{
    public class ProductDeveloper
    {
        public Guid ProductId { get; set; }
        public Product Product { get; set; }

        public Guid CompanyId { get; set; }
        public Company Company { get; set; }
    }
}