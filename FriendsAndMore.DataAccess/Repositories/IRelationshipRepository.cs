using System.Threading.Tasks;
using FriendsAndMore.DataAccess.Entities;

namespace FriendsAndMore.DataAccess.Repositories
{
    public interface IRelationshipRepository
    {
        Task<Relationship> GetRelationshipById(int id);
        Task<Relationship> UpdateRelationship(Relationship relationship);
        Task<Relationship> AddRelationship(Relationship relationship);
        Task DeleteRelationship(int id);
    }
}