using System;

namespace SpeedRun.Models.Models
{
    public class ProductGameMode
    {
        public Guid ProductId { get; set; }
        public Product Product { get; set; }

        public Guid GameModeId { get; set; }
        public GameMode GameMode { get; set; }
    }
}