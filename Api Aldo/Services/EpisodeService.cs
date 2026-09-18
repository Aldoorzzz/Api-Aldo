using Api_Aldo.Models;
using System.Net.Http.Json;
namespace Api_Aldo.Services

{
    public class EpisodeService
    {
        private readonly HttpClient _httpClient;

        public EpisodeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Episode>> GetEpisodes()
        {
            var response = await _httpClient.GetFromJsonAsync<EpisodeResponse>("episode");

            return response.Results;
        }
        public async Task<Episode> GetEpisode(int id)
        {
            var response = await _httpClient.GetAsync($"episode/{id}");

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            return await response.Content.ReadFromJsonAsync<Episode>();
        }
    }

    public class EpisodeResponse
    {
        public List<Episode> Results { get; set; }
    }
}
