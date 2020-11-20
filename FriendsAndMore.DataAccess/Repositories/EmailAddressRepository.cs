using System;
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
                .AsNoTracking()
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
        
        public async Task<EmailAddress> AddEmailAddress(EmailAddress emailAddress)
        {
            if (emailAddress.EmailAddressId != 0)
            {
                throw new Exception("New email addresses must not have a EmailAddressId");
            }

            var added = await _dbContext.EmailAddresses.AddAsync(emailAddress);
            await _dbContext.SaveChangesAsync();

            return added.Entity;
        }

        public async Task DeleteEmailAddress(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("EmailAddressId must be given", nameof(id));
            }

            var emailAddress = await _dbContext.EmailAddresses.FindAsync(id);

            if (emailAddress == null)
            {
                return;
            }

            _dbContext.EmailAddresses.Remove(emailAddress);
            await _dbContext.SaveChangesAsync();
        }
    }
}