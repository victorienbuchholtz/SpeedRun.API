﻿using System;
using System.Collections.Generic;
using SpeedRun.Models.Models.Product;

namespace SpeedRun.Models.Models
{
    public class Theme
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }

        public List<ProductTheme> Products { get; set; }
    }
}