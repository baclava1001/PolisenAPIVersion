using Microsoft.AspNetCore.Identity;
using System.Net.Http;

namespace BlazorAPIExperimental.Data
{
    public class Services
    {
        private readonly HttpClient _httpClient;
        public Services(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task <List<CrimeSummary>> GetDataByDate(string date)
        {
            try
            {
                var response = await _httpClient.GetAsync($"?DateTime={date}");
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<List<CrimeSummary>>();
            }
            catch(HttpRequestException ex)
            {
                Console.WriteLine($"HTTP request failed: {ex.Message}");
                List<CrimeSummary> crimeList = new List<CrimeSummary>();
                return crimeList;
            }
        }
        public async Task<List<CrimeSummary>> GetAllData()
        {
            try
            {
                var response = await _httpClient.GetAsync("");
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<List<CrimeSummary>>();
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"HTTP request failed: {ex.Message}");
                List<CrimeSummary> crimeList = new List<CrimeSummary>();
                return crimeList;
            }
        }
    }
}
