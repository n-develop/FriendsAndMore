using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FriendsAndMore.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

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

        public async Task<IEnumerable<Contact>> GetContacts()
        {
            return await _dbContext.Contacts.Take(20).ToListAsync();
        }
    }
}