using System;

namespace SpeedRun.Models.Models
{
    public class ProductTheme
    {
        public Guid ProductId { get; set; }
        public Product Product { get; set; }

        public Guid ThemeId { get; set; }
        public Theme Theme { get; set; }
    }
}