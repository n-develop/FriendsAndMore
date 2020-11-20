using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using FriendsAndMore.UI.Models;

namespace FriendsAndMore.UI.Services
{
    public class RelationshipService : IRelationshipService
    {
        private readonly HttpClient _httpClient;

        public RelationshipService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        
        public async Task<Relationship> GetRelationshipById(int relationshipId)
        {
            var result = await _httpClient.GetStringAsync("api/relationship/" + relationshipId);
            return JsonSerializer.Deserialize<Relationship>(result, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<Relationship> AddRelationship(Relationship relationship)
        {
            var serializedRelationship = JsonSerializer.Serialize(relationship, new JsonSerializerOptions{ PropertyNameCaseInsensitive = true});
            var content = new StringContent(serializedRelationship, Encoding.UTF8, "application/json");
            
            var addedResult = await _httpClient.PostAsync("api/relationship", content);
            var response = await addedResult.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Relationship>(response, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task UpdateRelationship(Relationship relationship)
        {
            var serializedRelationship = JsonSerializer.Serialize(relationship, new JsonSerializerOptions{ PropertyNameCaseInsensitive = true});
            var content = new StringContent(serializedRelationship, Encoding.UTF8, "application/json");
            
            await _httpClient.PutAsync("api/relationship", content);
        }

        public async Task DeleteRelationship(int relationshipId)
        {
            await _httpClient.DeleteAsync("api/relationship/" + relationshipId);
        }
    }
}