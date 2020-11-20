using System.Threading.Tasks;
using FriendsAndMore.UI.Models;

namespace FriendsAndMore.UI.Services
{
    public interface IEmailService
    {
        Task<EmailAddress> GetEmailAddressById(int emailAddressId);
        Task<EmailAddress> AddEmailAddress(EmailAddress emailAddress);
        Task UpdateEmailAddress(EmailAddress emailAddress);
        Task DeleteEmailAddress(int emailAddressId);
    }
}