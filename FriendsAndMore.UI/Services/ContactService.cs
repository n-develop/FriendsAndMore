using System.Collections.Generic;
using System.Net.Http;
using System.Text;
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

        public async Task<Contact> GetContactById(int contactId)
        {
            var result = await _httpClient.GetStringAsync("api/contact/" + contactId);
            return JsonSerializer.Deserialize<Contact>(result, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<Contact> AddContact(Contact contact)
        {
            var serializedContact = JsonSerializer.Serialize(contact, new JsonSerializerOptions{ PropertyNameCaseInsensitive = true});
            var content = new StringContent(serializedContact, Encoding.UTF8, "application/json");
            
            var addedResult = await _httpClient.PostAsync("api/contact", content);
            var response = await addedResult.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Contact>(response, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task UpdateContact(Contact contact)
        {
            var serializedContact = JsonSerializer.Serialize(contact, new JsonSerializerOptions{ PropertyNameCaseInsensitive = true});
            var content = new StringContent(serializedContact, Encoding.UTF8, "application/json");
            
            await _httpClient.PutAsync("api/contact", content);
        }
        
        public async Task DeleteContact(int contactId)
        {
            await _httpClient.DeleteAsync("api/contact/" + contactId);
        }
        
        public async Task ToggleFavorite(int contactId)
        {
            await _httpClient.PutAsync("api/Favorite", new StringContent(contactId.ToString(), Encoding.UTF8, "application/json"));
        }
    }
}