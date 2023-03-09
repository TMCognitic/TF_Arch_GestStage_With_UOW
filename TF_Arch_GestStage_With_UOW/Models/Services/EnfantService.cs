using System.Text.Json;
using TF_Arch_GestStage_With_UOW.Models.Entities;
using TF_Arch_GestStage_With_UOW.Models.Repositories;

namespace TF_Arch_GestStage_With_UOW.Models.Services
{
    public class EnfantService : IEnfantRepository
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public EnfantService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public void Add(Enfant enfant, int stageId)
        {
            using (HttpClient client = _httpClientFactory.CreateClient("Api"))
            {
                var info = new { enfant.Nom, enfant.Prenom, StageId = stageId };
                HttpContent httpContent = new StringContent(JsonSerializer.Serialize(info));
                httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                using (HttpResponseMessage response = client.PostAsync($"enfant", httpContent).Result)
                {
                    response.EnsureSuccessStatusCode();
                }
            }
        }

        public IEnumerable<Enfant>? Get(int stageId)
        {
            using (HttpClient client = _httpClientFactory.CreateClient("Api"))
            {
                using (HttpResponseMessage response = client.GetAsync($"enfant/bystage/{stageId}").Result)
                {
                    response.EnsureSuccessStatusCode();

                    string json = response.Content.ReadAsStringAsync().Result;

                    return JsonSerializer.Deserialize<Enfant[]>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                }
            }
        }
    }
}
