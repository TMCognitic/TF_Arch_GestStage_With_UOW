using System.Text.Json;
using TF_Arch_GestStage_With_UOW.Models.Entities;
using TF_Arch_GestStage_With_UOW.Models.Repositories;

namespace TF_Arch_GestStage_With_UOW.Models.Services
{
    public class StageService : IStageRepository
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public StageService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IEnumerable<Stage>? Get()
        {
            using(HttpClient client = _httpClientFactory.CreateClient("Api"))
            {
                using(HttpResponseMessage response = client.GetAsync("stage").Result)
                {
                    response.EnsureSuccessStatusCode();

                    string json = response.Content.ReadAsStringAsync().Result;

                    return JsonSerializer.Deserialize<Stage[]>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                }
            }
        }

        public Stage Get(int id)
        {
            using (HttpClient client = _httpClientFactory.CreateClient("Api"))
            {
                using (HttpResponseMessage response = client.GetAsync($"stage/{id}").Result)
                {
                    response.EnsureSuccessStatusCode();

                    string json = response.Content.ReadAsStringAsync().Result;

                    return JsonSerializer.Deserialize<Stage>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true })!;
                }
            }
        }
    }
}
