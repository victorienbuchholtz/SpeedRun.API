using Newtonsoft.Json;
using SpeedRun.Models.Models.Product;
using SpeedRun.Services.Builder;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SpeedRun.Services.Services
{
    public class IgdbService
    {
        private HttpClient _client { get; }

        public IgdbService(HttpClient client)
        {
            _client = client;
        }

        public async Task<List<IgdbGameMinified>> GetSimilarProductNameAsync(string name)
        {
            var response = await _client.PostAsync("/games/",
                new ByteArrayContent(Encoding.UTF8.GetBytes("f name;w name~\"" + name + "\"*;"))); 

            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync();
            var resultDeserialized = JsonConvert.DeserializeObject<List<IgdbGameMinified>>(result);

            if (!result.Any()) return null;
            return resultDeserialized;
        }

        public async Task<Product> GetGameById(int id)
        {
            var response = await _client.PostAsync("/games/",
                new ByteArrayContent(Encoding.UTF8.GetBytes("f name,first_release_date,summary,rating,cover.url,screenshots.url;w id=" + id + ";")));

            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync();
            var res = JsonConvert.DeserializeObject<List<IgdbGame>>(result);

            if (!result.Any()) return null;
            ProductBuilder p = new ProductBuilder();
            Product test = p.BuildProduct(res.First());
            return test;
        }
    }
}