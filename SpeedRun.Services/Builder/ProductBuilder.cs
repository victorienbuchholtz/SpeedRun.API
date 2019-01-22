using SpeedRun.Models.Models;
using SpeedRun.Models.Models.Product;
using System;

namespace SpeedRun.Services.Builder
{
    public class ProductBuilder
    {

        public Product BuildProduct(IgdbGame game)
        {
            Product product = new Product
            {
                Name = game.name,
                Summary = game.summary,
                TotalRating = (int)game.rating,
                FirstReleaseDate = UnixTimestampToDateTime(game.first_release_date),
                CoverUrl = game.cover.url
            };

            foreach (IgdbScreenshot screenshot in game.screenshots)
            {
                Screenshot s = new Screenshot();
                s.ScreenshotUrl = screenshot.url;
                
            }

            return product;
        }

        public DateTime UnixTimestampToDateTime(int timestamp)
        {
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            dateTime = dateTime.AddSeconds(timestamp);

            return dateTime;
        }

    }
}
