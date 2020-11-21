using System;
using System.Threading.Tasks;
using FriendsAndMore.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace FriendsAndMore.DataAccess.Repositories
{
    public class TelephoneNumberRepository : ITelephoneNumberRepository
    {
        private readonly DatabaseContext _dbContext;

        public TelephoneNumberRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<TelephoneNumber> GetTelephoneNumberById(int id)
        {
            return await _dbContext.TelephoneNumbers.Include(e => e.Contact)
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<TelephoneNumber> UpdateTelephoneNumber(TelephoneNumber telephoneNumber)
        {
            var foundEntity = await _dbContext.TelephoneNumbers
                .FirstOrDefaultAsync(e => e.Id == telephoneNumber.Id);

            if (foundEntity != null)
            {
                foundEntity.Type = telephoneNumber.Type;
                foundEntity.Telephone = telephoneNumber.Telephone;

                await _dbContext.SaveChangesAsync();

                return foundEntity;
            }

            return null;
        }

        public async Task<TelephoneNumber> AddTelephoneNumber(TelephoneNumber telephoneNumber)
        {
            if (telephoneNumber.Id != 0)
            {
                throw new Exception("New status update must not have a StatusUpdateId");
            }

            var added = await _dbContext.TelephoneNumbers.AddAsync(telephoneNumber);
            await _dbContext.SaveChangesAsync();

            return added.Entity;
        }

        public async Task DeleteTelephoneNumber(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("id must be given", nameof(id));
            }

            var telephoneNumber = await _dbContext.TelephoneNumbers.FindAsync(id);

            if (telephoneNumber == null)
            {
                return;
            }

            _dbContext.TelephoneNumbers.Remove(telephoneNumber);
            await _dbContext.SaveChangesAsync();
        }
    }
}