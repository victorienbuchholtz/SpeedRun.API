using System;
using System.Linq;

namespace SpeedRun.Services.Generators
{
    public class CdKeyGenerator
    {
        private static Random random = new Random();

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public string Generate(int partitionLength)
        {
            var cdKey = "";
            for(int i = 0; i <= 4; i++)
            {
                cdKey += RandomString(partitionLength);
                if(HowManyTimeThisCharOccured(cdKey, '-') < 4)
                {
                    cdKey += '-';
                }
            }
            return cdKey;
        }

        public int HowManyTimeThisCharOccured(string fullString, char character)
        {
            return fullString.Count(c => c == character);
        }
    }
}
