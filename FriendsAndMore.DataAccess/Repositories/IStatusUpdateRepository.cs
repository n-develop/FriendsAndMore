using System.Threading.Tasks;
using FriendsAndMore.DataAccess.Entities;

namespace FriendsAndMore.DataAccess.Repositories
{
    public interface IStatusUpdateRepository
    {
        Task<StatusUpdate> GetStatusUpdateById(int id);
        Task<StatusUpdate> UpdateStatusUpdate(StatusUpdate statusUpdate);
        Task<StatusUpdate> AddStatusUpdate(StatusUpdate statusUpdate);
        Task DeleteStatusUpdate(int id);
    }
}