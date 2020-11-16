using System.Collections.Generic;
using System.Threading.Tasks;
using FriendsAndMore.DataAccess.Entities;

namespace FriendsAndMore.DataAccess.Repositories
{
    public interface IContactRepository
    {
        Task<Contact> GetContactById(int contactId);
        Task<IEnumerable<Contact>> GetContacts();
        Task<Contact> UpdateContact(Contact contact);
        Task<Contact> AddContact(Contact contact);
    }
}