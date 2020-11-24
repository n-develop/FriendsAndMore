using System.Threading.Tasks;
using FriendsAndMore.DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FriendsAndMore.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FavoriteController : Controller
    {
        private readonly IContactRepository _contactRepository;

        public FavoriteController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }
        
        [HttpPut]
        public async Task<IActionResult> ToggleFavorite([FromBody]int contactId)
        {
            if (contactId <= 0)
            {
                return BadRequest();
            }

            await _contactRepository.ToggleFavorite(contactId);

            return NoContent();
        }
    }
}