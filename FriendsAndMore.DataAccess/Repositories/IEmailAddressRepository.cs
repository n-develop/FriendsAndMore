using System.Threading.Tasks;
using FriendsAndMore.DataAccess.Entities;

namespace FriendsAndMore.DataAccess.Repositories
{
    public interface IEmailAddressRepository
    {
        Task<EmailAddress> GetEmailAddressById(int id);
        Task<EmailAddress> UpdateEmailAddress(EmailAddress emailAddress);
        Task<EmailAddress> AddEmailAddress(EmailAddress emailAddress);
    }
}