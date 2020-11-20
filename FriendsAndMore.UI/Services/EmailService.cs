using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using FriendsAndMore.UI.Models;

namespace FriendsAndMore.UI.Services
{
    class EmailService : IEmailService
    {
        private readonly HttpClient _httpClient;

        public EmailService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        
        public async Task<EmailAddress> GetEmailAddressById(int emailAddressId)
        {
            var result = await _httpClient.GetStringAsync("api/email/" + emailAddressId);
            return JsonSerializer.Deserialize<EmailAddress>(result, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public Task<EmailAddress> AddEmailAddress(EmailAddress emailAddress)
        {
            throw new System.NotImplementedException();
        }

        public async Task UpdateEmailAddress(EmailAddress emailAddress)
        {
            var serializedEmail = JsonSerializer.Serialize(emailAddress, new JsonSerializerOptions{ PropertyNameCaseInsensitive = true});
            var content = new StringContent(serializedEmail, Encoding.UTF8, "application/json");
            
            await _httpClient.PutAsync("api/email", content);
        }

        public Task DeleteEmailAddress(int emailAddressId)
        {
            throw new System.NotImplementedException();
        }
    }
}