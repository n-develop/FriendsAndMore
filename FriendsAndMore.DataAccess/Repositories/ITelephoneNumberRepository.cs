using System.Threading.Tasks;
using FriendsAndMore.DataAccess.Entities;

namespace FriendsAndMore.DataAccess.Repositories
{
    public interface ITelephoneNumberRepository
    {
        Task<TelephoneNumber> GetTelephoneNumberById(int id);
        Task<TelephoneNumber> UpdateTelephoneNumber(TelephoneNumber telephoneNumber);
        Task<TelephoneNumber> AddTelephoneNumber(TelephoneNumber telephoneNumber);
        Task DeleteTelephoneNumber(int id);
    }
}