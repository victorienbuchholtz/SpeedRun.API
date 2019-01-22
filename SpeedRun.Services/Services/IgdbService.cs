using Newtonsoft.Json;
using SpeedRun.Models.Models;
using SpeedRun.Models.Models.Product;
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

        public async Task<IgdbGame> GetGameByName(string name)
        {
            var response = await _client.PostAsync("/games/",
                new ByteArrayContent(Encoding.UTF8.GetBytes("f name,first_release_date,summary,rating,cover.url,screenshots.url;w name~\"" + name + "\"*;")));

            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync();
            var res = JsonConvert.DeserializeObject<List<IgdbGame>>(result);


            if (!result.Any()) return null;
            return res.First();
        }

        public async Task<Product> GetGameById(int id)
        {
            var response = await _client.GetAsync("/games/" + id);
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsAsync<IEnumerable<Product>>();
            if (!result.Any()) return null;

            return result.First();
        }

        public async Task<IEnumerable<Product>> GetPopularGames(int platformId, int limit = 10)
        {
            var response = await _client.GetAsync($"/games/?fields=name,url,summary&order=popularity:desc&filter[platforms][eq]={platformId}&limit={limit}");
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsAsync<IEnumerable<Product>>();
            if (!result.Any()) return null;

            return result;
        }
    }
}