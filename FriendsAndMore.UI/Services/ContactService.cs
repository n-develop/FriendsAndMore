using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using FriendsAndMore.UI.Models;

namespace FriendsAndMore.UI.Services
{
    public class ContactService : IContactService
    {
        private readonly HttpClient _httpClient;

        public ContactService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        
        public async Task<IEnumerable<Contact>> GetAllContacts()
        {
            var result = await _httpClient.GetStringAsync("api/contact");
            return JsonSerializer.Deserialize<IEnumerable<Contact>>(result, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public Task<Contact> GetContactById(int countryId)
        {
            throw new System.NotImplementedException();
        }
    }
}