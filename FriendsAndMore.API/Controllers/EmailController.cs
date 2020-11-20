using System.Threading.Tasks;
using FriendsAndMore.DataAccess.Entities;
using FriendsAndMore.DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FriendsAndMore.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmailController : Controller
    {
        private readonly IEmailAddressRepository _emailAddressRepository;

        public EmailController(IEmailAddressRepository emailAddressRepository)
        {
            _emailAddressRepository = emailAddressRepository;
        }
        
        [HttpGet("{id}")]
        public async Task<EmailAddress> Get(int id)
        {
            return await _emailAddressRepository.GetEmailAddressById(id);
        }
    }
}