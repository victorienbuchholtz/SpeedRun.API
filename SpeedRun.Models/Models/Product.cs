using System;
using System.Collections.Generic;
using System.Linq;
using SpeedRun.Models.Enums;
using SpeedRun.Models.Interfaces;

namespace SpeedRun.Models.Models
{
    public class Product : IIncludeObject
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Summary { get; set; }
        public string StoryLine { get; set; }
        public int TotalRating { get; set; }
        public int RatingCount { get; set; }
        public DateTime FirstReleaseDate { get; set; }
        public string CoverUrl { get; set; }
        public int PegiRating { get; set; }
        public double Price { get; set; }
        public double Taxes { get; set; }
        public int DeliveryTime { get; set; }
        public bool Active { get; set; }
        public bool Featured { get; set; }
        public int Inventory => GetInventory();

        public int IgdbId { get; set; }

        public List<Screenshot> Screenshots { get; set; }
        public List<InventoryOperation> InventoryOperations { get; set; }
        public List<Basket> Baskets { get; set; }

        public Product(string name, string summary, string storyLine, int totalRating, int ratingCount, DateTime firstReleaseDate, string coverUrl, int pegiRating, double price, double taxes, int deliveryTime, bool active, bool featured)
        {
            Name = name;
            Summary = summary;
            StoryLine = storyLine;
            TotalRating = totalRating;
            RatingCount = ratingCount;
            FirstReleaseDate = firstReleaseDate;
            CoverUrl = coverUrl;
            PegiRating = pegiRating;
            Price = price;
            Taxes = taxes;
            DeliveryTime = deliveryTime;
            Active = active;
            Featured = featured;
        }

        public Product()
        {
        }

        private int GetInventory()
        {
            if (InventoryOperations != null)
            {
                return InventoryOperations.Count(x => x.OperationType == OperationType.Add) - 
                       InventoryOperations.Count(x => x.OperationType == OperationType.Withdraw);
            }
            return 0;
        }

        public List<string> IncludesNeeded()
        {
            return new List<string>{ "InventoryOperations", "Screenshots" };
        }
    }
}
