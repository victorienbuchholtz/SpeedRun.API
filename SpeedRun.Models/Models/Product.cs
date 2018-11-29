using System;
using System.Collections.Generic;

namespace SpeedRun.Models.Models
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

        public List<string> ScreenshotUrls { get; set; }
        public List<string> VideoUrls { get; set; }

        public List<OrderedProduct> OrderedProducts { get; set; }
        public Franchise Franchise { get; set; }
        public List<Company> Developpers { get; set; }
        public List<Company> Publishers { get; set; }
        public List<GameEngine> GameEngines { get; set; }
        public List<GameMode> GameModes { get; set; }
        public List<Genre> Genres { get; set; }
        public List<Theme> Themes { get; set; }

    }
}
