using System.Threading.Tasks;
using FriendsAndMore.UI.Models;

namespace FriendsAndMore.UI.Services
{
    public interface IRelationshipService
    {
        Task<Relationship> GetRelationshipById(int relationshipId);
        Task<Relationship> AddRelationship(Relationship relationship);
        Task UpdateRelationship(Relationship relationship);
        Task DeleteRelationship(int relationshipId);
    }
}