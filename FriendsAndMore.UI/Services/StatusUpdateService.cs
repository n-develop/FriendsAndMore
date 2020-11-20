using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using FriendsAndMore.UI.Models;

namespace FriendsAndMore.UI.Services
{
    public class StatusUpdateService : IStatusUpdateService
    {
        private readonly HttpClient _httpClient;

        public StatusUpdateService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        
        public async Task<StatusUpdate> GetStatusUpdateById(int statusUpdateId)
        {
            var result = await _httpClient.GetStringAsync("api/statusupdate/" + statusUpdateId);
            return JsonSerializer.Deserialize<StatusUpdate>(result, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<StatusUpdate> AddStatusUpdate(StatusUpdate statusUpdate)
        {
            var serializedStatusUpdate = JsonSerializer.Serialize(statusUpdate, new JsonSerializerOptions{ PropertyNameCaseInsensitive = true});
            var content = new StringContent(serializedStatusUpdate, Encoding.UTF8, "application/json");
            
            var addedResult = await _httpClient.PostAsync("api/statusupdate", content);
            var response = await addedResult.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<StatusUpdate>(response, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task UpdateStatusUpdate(StatusUpdate statusUpdate)
        {
            var serializedStatusUpdate = JsonSerializer.Serialize(statusUpdate, new JsonSerializerOptions{ PropertyNameCaseInsensitive = true});
            var content = new StringContent(serializedStatusUpdate, Encoding.UTF8, "application/json");
            
            await _httpClient.PutAsync("api/statusupdate", content);        }

        public async Task DeleteStatusUpdate(int statusUpdateId)
        {
            await _httpClient.DeleteAsync("api/statusupdate/" + statusUpdateId);        }
    }
}