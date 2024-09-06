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

        public async Task<List<Fees>> GetFeesFromApi()
        {
            var response = await _httpClient.GetAsync("https://api.opendata.esett.com/EXP05/Fees");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var feesList = JsonConvert.DeserializeObject<List<Fees>>(json);

            return feesList ?? throw new Exception("Failed to deserialize the response from the API.");
        }
        public async Task<List<Bank>> GetBanksFromApi()
        {    
                var response = await _httpClient.GetAsync("https://api.opendata.esett.com/EXP06/Banks");
                response.EnsureSuccessStatusCode();


                var json = await response.Content.ReadAsStringAsync();
                var banksList = JsonConvert.DeserializeObject<List<Bank>>(json);

                return banksList ?? throw new Exception("Failed to deserialize the response from the API.");
     
        }
    }
}
