using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using FriendsAndMore.UI.Models;

namespace FriendsAndMore.UI.Services
{
    public class EntityDataService : IEntityDataService
    {
        private readonly HttpClient _httpClient;

        public EntityDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        
        public async Task<T> GetById<T>(int id)
        {
            var result = await _httpClient.GetStringAsync("api/" + typeof(T).Name + "/" + id);
            return JsonSerializer.Deserialize<T>(result, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<T> Add<T>(T entity)
        {
            var serialized = JsonSerializer.Serialize(entity, new JsonSerializerOptions{ PropertyNameCaseInsensitive = true});
            var content = new StringContent(serialized, Encoding.UTF8, "application/json");
            
            var addedResult = await _httpClient.PostAsync("api/" + typeof(T).Name, content);
            var response = await addedResult.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(response, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task Update<T>(T entity)
        {
            var serialized = JsonSerializer.Serialize(entity, new JsonSerializerOptions{ PropertyNameCaseInsensitive = true});
            var content = new StringContent(serialized, Encoding.UTF8, "application/json");
            
            await _httpClient.PutAsync("api/" + typeof(T).Name, content);
        }

        public async Task Delete<T>(int id)
        {
            await _httpClient.DeleteAsync("api/" + typeof(T).Name + "/" + id);
        }
    }
}