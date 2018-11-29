using System;

namespace SpeedRun.Models.Models
{
    public class ProductGameEngine
    {
        public Guid ProductId { get; set; }
        public Product Product { get; set; }

        public Guid GameEngineId { get; set; }
        public GameEngine GameEngine { get; set; }
    }
}