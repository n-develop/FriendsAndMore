using System.Threading.Tasks;
using FriendsAndMore.UI.Models;

namespace FriendsAndMore.UI.Services
{
    class EmailService : IEmailService
    {
        public Task<EmailAddress> GetEmailAddressById(int emailAddressId)
        {
            throw new System.NotImplementedException();
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