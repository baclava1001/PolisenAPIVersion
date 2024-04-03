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
        public async Task<List<CrimeSummary>> GetData()
        {
            try
            {
                var response = await _httpClient.GetAsync("?locationname=Umeå");
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<List<CrimeSummary>>();
            }
            catch(HttpRequestException ex)
            {
                Console.WriteLine($"HTTP request failed: {ex.Message}");
                return new List<CrimeSummary>();
            }
        }
    }
}
