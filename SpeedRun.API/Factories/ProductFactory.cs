using System;
using System.Collections.Generic;
using SpeedRun.Models.Models.Product;

namespace SpeedRun.API.Factories
{
    public class ProductFactory
    {
        public static List<string> GetProductNames(string name)
        {
            var gameNames = new List<string>();
            for (int i = 1; i <= 10; i++)
            {
                gameNames.Add($"{name} {i}");
            }
            return gameNames;
        }

        public static Product GetProduct(string name)
        {
            var inventory = new Random().Next(1,10);
            return new Product(name,"summary","storyLine",5,200,DateTime.Now, "https://images.anandtech.com/doci/12740/steam_valve_678_678x452.jpg",18,30,20,2,true,false);
        }
    }
}