using System.Threading.Tasks;
using FriendsAndMore.DataAccess.Entities;

namespace FriendsAndMore.DataAccess.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly DatabaseContext _dbContext;

        public ContactRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<Contact> GetContactById(int contactId)
        {
            return await _dbContext.Contacts.FindAsync(contactId);
        }
    }
}