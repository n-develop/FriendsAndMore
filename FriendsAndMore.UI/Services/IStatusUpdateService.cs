using System.Threading.Tasks;
using FriendsAndMore.UI.Models;

namespace FriendsAndMore.UI.Services
{
    public interface IStatusUpdateService
    {
        Task<StatusUpdate> GetStatusUpdateById(int statusUpdateId);
        Task<StatusUpdate> AddStatusUpdate(StatusUpdate statusUpdate);
        Task UpdateStatusUpdate(StatusUpdate statusUpdate);
        Task DeleteStatusUpdate(int statusUpdateId);
    }
}