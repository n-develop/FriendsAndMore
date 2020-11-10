using System.Threading.Tasks;
using FriendsAndMore.DataAccess.Entities;

namespace FriendsAndMore.DataAccess.Repositories
{
    public interface IContactRepository
    {
        Task<Contact> GetContactById(int contactId);
    }
}