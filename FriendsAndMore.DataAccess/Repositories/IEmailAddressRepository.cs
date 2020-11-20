using System.Threading.Tasks;
using FriendsAndMore.DataAccess.Entities;
using Microsoft.EntityFrameworkCore.Storage;

namespace FriendsAndMore.DataAccess.Repositories
{
    public interface IEmailAddressRepository
    {
        Task<EmailAddress> GetEmailAddressById(int id);
    }
}