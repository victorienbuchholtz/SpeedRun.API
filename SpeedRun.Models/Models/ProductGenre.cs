﻿using System;

namespace SpeedRun.Models.Models
{
    public class ProductGenre
    {
        public Guid ProductId { get; set; }
        public Product Product { get; set; }

        public Guid GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}