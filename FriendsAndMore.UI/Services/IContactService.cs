using System.Collections.Generic;
using System.Threading.Tasks;
using FriendsAndMore.UI.Models;

namespace FriendsAndMore.UI.Services
{
    public interface IContactService
    {
        Task<IEnumerable<Contact>> GetAllContacts();
        Task<Contact> GetContactById(int countryId);
        Task<Contact> AddContact(Contact contact);
        Task UpdateContact(Contact contact);
    }
}