using System;
using System.Collections.Generic;

namespace SpeedRun.Models.Models.Product
{
    public class Product
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
        public int Inventory { get; set; }

        public List<Screenshot> Screenshots { get; set; }
        public List<Video> Videos { get; set; }
        public List<OrderedProduct> OrderedProducts { get; set; }
        public Franchise Franchise { get; set; }

        // Many to many
        public List<ProductDeveloper> Developers { get; set; }
        public List<ProductPublisher> Publishers { get; set; }
        public List<ProductGameEngine> GameEngines { get; set; }
        public List<ProductGameMode> GameModes { get; set; }
        public List<ProductGenre> Genres { get; set; }
        public List<ProductTheme> Themes { get; set; }

        public Product(string name, string summary, string storyLine, int totalRating, int ratingCount, DateTime firstReleaseDate, string coverUrl, int pegiRating, double price, double taxes, int deliveryTime, bool active, int inventory)
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
            Inventory = inventory;
        }
    }
}
