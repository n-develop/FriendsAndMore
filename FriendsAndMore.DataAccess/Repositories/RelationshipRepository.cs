using System;
using System.Threading.Tasks;
using FriendsAndMore.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace FriendsAndMore.DataAccess.Repositories
{
    public class RelationshipRepository : IRelationshipRepository
    {
        private readonly DatabaseContext _dbContext;

        public RelationshipRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<Relationship> GetRelationshipById(int id)
        {
            return await _dbContext.Relationships.Include(e => e.Contact)
                .AsNoTracking()
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<Relationship> UpdateRelationship(Relationship relationship)
        {
            var foundRelationship = await _dbContext.Relationships
                .FirstOrDefaultAsync(e => e.Id == relationship.Id);

            if (foundRelationship != null)
            {
                foundRelationship.Type = relationship.Type;
                foundRelationship.Person = relationship.Person;

                await _dbContext.SaveChangesAsync();

                return foundRelationship;
            }

            return null;
        }

        public async Task<Relationship> AddRelationship(Relationship relationship)
        {
            if (relationship.Id != 0)
            {
                throw new Exception("New relationship must not have a RelationshipId");
            }

            var added = await _dbContext.Relationships.AddAsync(relationship);
            await _dbContext.SaveChangesAsync();

            return added.Entity;
        }

        public async Task DeleteRelationship(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("RelationshipId must be given", nameof(id));
            }

            var relationship = await _dbContext.Relationships.FindAsync(id);

            if (relationship == null)
            {
                return;
            }

            _dbContext.Relationships.Remove(relationship);
            await _dbContext.SaveChangesAsync();
        }
    }
}