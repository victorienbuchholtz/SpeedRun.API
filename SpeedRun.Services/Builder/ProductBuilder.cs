using SpeedRun.Models.Models;
using SpeedRun.Models.Models.Product;
using System;
using System.Collections.Generic;

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
                IgdbId = game.id
            };
            if(game.cover != null)
                product.CoverUrl = ReplaceScreenSize("screenshot_big", game.cover.url);

            if (game.screenshots != null)
            {
                product.Screenshots = new List<Screenshot>();
                foreach (IgdbScreenshot screenshot in game.screenshots)
                {
                    Screenshot screen = new Screenshot
                    {
                        ScreenshotUrl = ReplaceScreenSize("screenshot_huge", screenshot.url)
                    };
                    product.Screenshots.Add(screen);
                }
            }

            return product;
        }

        public string ReplaceScreenSize(string screenSize, string url)
        {
            return url.Replace("thumb", screenSize);
        }

        public DateTime UnixTimestampToDateTime(int timestamp)
        {
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            dateTime = dateTime.AddSeconds(timestamp);

            return dateTime;
        }

    }
}
