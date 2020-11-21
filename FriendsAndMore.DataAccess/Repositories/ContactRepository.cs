using System;
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
            return await _dbContext.Contacts
                .Include(c => c.EmailAddresses)
                .Include(c => c.Relationships)
                .Include(c => c.StatusUpdates)
                .Include(c => c.TelephoneNumbers)
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == contactId);
        }

        public async Task<IEnumerable<Contact>> GetContacts()
        {
            return await _dbContext.Contacts
                .Include(c => c.EmailAddresses)
                .AsSplitQuery()
                .OrderBy(c => c.Id)
                .AsNoTracking()
                .Take(20)
                .ToListAsync();
        }

        public async Task<Contact> UpdateContact(Contact contact)
        {
            var foundContact = await _dbContext.Contacts.FirstOrDefaultAsync(e => e.Id == contact.Id);

            if (foundContact != null)
            {
                foundContact.FirstName = contact.FirstName;
                foundContact.LastName = contact.LastName;
                foundContact.MiddleName = contact.MiddleName;
                foundContact.Address = contact.Address;
                foundContact.Employer = contact.Employer;
                foundContact.BusinessTitle = contact.BusinessTitle;
                foundContact.Tags = contact.Tags;
                foundContact.Birthday = contact.Birthday;

                await _dbContext.SaveChangesAsync();

                return foundContact;
            }

            return null;
        }

        public async Task<Contact> AddContact(Contact contact)
        {
            if (contact.Id != 0)
            {
                throw new Exception("New contacts must not have a ContactId");
            }

            var added = await _dbContext.Contacts.AddAsync(contact);
            await _dbContext.SaveChangesAsync();

            return added.Entity;
        }

        public async Task DeleteContact(int contactId)
        {
            if (contactId <= 0)
            {
                throw new ArgumentException("ContactId must be given", nameof(contactId));
            }

            var contact = await _dbContext.Contacts.FindAsync(contactId);

            if (contact == null)
            {
                return;
            }

            _dbContext.Contacts.Remove(contact);
            await _dbContext.SaveChangesAsync();
        }
    }
}