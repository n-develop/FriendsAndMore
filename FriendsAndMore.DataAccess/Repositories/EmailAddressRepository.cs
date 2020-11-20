using System.Threading.Tasks;
using FriendsAndMore.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace FriendsAndMore.DataAccess.Repositories
{
    public class EmailAddressRepository : IEmailAddressRepository
    {
        private readonly DatabaseContext _dbContext;

        public EmailAddressRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<EmailAddress> GetEmailAddressById(int id)
        {
            return await _dbContext.EmailAddresses.Include(e => e.Contact)
                .FirstOrDefaultAsync(e => e.EmailAddressId == id);
        }
        
        public async Task<EmailAddress> UpdateEmailAddress(EmailAddress emailAddress)
        {
            var foundEmailAddress = await _dbContext.EmailAddresses
                .FirstOrDefaultAsync(e => e.EmailAddressId == emailAddress.EmailAddressId);

            if (foundEmailAddress != null)
            {
                foundEmailAddress.Type = emailAddress.Type;
                foundEmailAddress.Email = emailAddress.Email;

                await _dbContext.SaveChangesAsync();

                return foundEmailAddress;
            }

            return null;
        }
    }
}