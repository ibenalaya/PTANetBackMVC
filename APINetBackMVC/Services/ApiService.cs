using APINetBackMVC.Models.Entities;
using Newtonsoft.Json;

namespace APINetBackMVC.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Fees> GetDataFromApi()
        {
            var response = await _httpClient.GetAsync("https://api.opendata.esett.com/your-service-endpoint");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var fees = JsonConvert.DeserializeObject<Fees>(json);

            return fees ?? throw new Exception("Failed to deserialize the response from the API.");
        }
    }
}
