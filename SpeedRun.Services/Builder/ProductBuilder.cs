using SpeedRun.Models.Models;
using SpeedRun.Models.Models.Igdb;
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
                Name = game.Name,
                Summary = game.Summary,
                TotalRating = (int)game.Rating,
                FirstReleaseDate = UnixTimestampToDateTime(game.First_release_date),
                IgdbId = game.Id
            };

            if(game.Cover != null && game.Cover.Url != null)
                product.CoverUrl = ReplaceScreenSize("screenshot_big", game.Cover.Url);

            if (game.Screenshots != null)
            {
                product.Screenshots = new List<Screenshot>();
                foreach (IgdbScreenshot screenshot in game.Screenshots)
                {
                    if (screenshot.Url != null)
                    {
                        Screenshot screen = new Screenshot
                        {
                            ScreenshotUrl = ReplaceScreenSize("screenshot_huge", screenshot.Url)
                        };
                        product.Screenshots.Add(screen);
                    }
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
