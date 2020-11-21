using System;
using System.Threading.Tasks;
using FriendsAndMore.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace FriendsAndMore.DataAccess.Repositories
{
    public class StatusUpdateRepository : IStatusUpdateRepository
    {
        private readonly DatabaseContext _dbContext;

        public StatusUpdateRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<StatusUpdate> GetStatusUpdateById(int id)
        {
            return await _dbContext.StatusUpdates.Include(e => e.Contact)
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<StatusUpdate> UpdateStatusUpdate(StatusUpdate statusUpdate)
        {
            var foundStatusUpdate = await _dbContext.StatusUpdates
                .FirstOrDefaultAsync(e => e.Id == statusUpdate.Id);

            if (foundStatusUpdate != null)
            {
                foundStatusUpdate.StatusText = statusUpdate.StatusText;
                foundStatusUpdate.Created = statusUpdate.Created;

                await _dbContext.SaveChangesAsync();

                return foundStatusUpdate;
            }

            return null;
        }

        public async Task<StatusUpdate> AddStatusUpdate(StatusUpdate statusUpdate)
        {
            if (statusUpdate.Id != 0)
            {
                throw new Exception("New status update must not have a StatusUpdateId");
            }

            var added = await _dbContext.StatusUpdates.AddAsync(statusUpdate);
            await _dbContext.SaveChangesAsync();

            return added.Entity;
        }

        public async Task DeleteStatusUpdate(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("StatusUpdateId must be given", nameof(id));
            }

            var statusUpdate = await _dbContext.StatusUpdates.FindAsync(id);

            if (statusUpdate == null)
            {
                return;
            }

            _dbContext.StatusUpdates.Remove(statusUpdate);
            await _dbContext.SaveChangesAsync();
        }
    }
}