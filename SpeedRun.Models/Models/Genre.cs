using System;
using System.Collections.Generic;
using SpeedRun.Models.Models.Product;

namespace SpeedRun.Models.Models
{
    public class Genre
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }

        // Many to many
        public List<ProductGenre> Products { get; set; }
    }
}