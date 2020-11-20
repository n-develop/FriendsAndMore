using System.Net.Http;
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

        public Task UpdateEmailAddress(EmailAddress emailAddress)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteEmailAddress(int emailAddressId)
        {
            throw new System.NotImplementedException();
        }
    }
}