using System.Threading.Tasks;

namespace FriendsAndMore.UI.Services
{
    public interface IEntityDataService
    {
        Task<T> GetById<T>(int id);
        Task<T> Add<T>(T entity);
        Task Update<T>(T entity);
        Task Delete<T>(int id);
    }
}