using System.Threading.Tasks;
using FriendsAndMore.DataAccess.Entities;

namespace FriendsAndMore.DataAccess.Repositories
{
    public class ContactRepository : IContactRepository
    {
        public Task<Contact> GetContactById(int contactId)
        {
            throw new System.NotImplementedException();
        }
    }
}