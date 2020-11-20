using System.Net;
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
        
        [HttpPut]
        public IActionResult Update([FromBody] EmailAddress emailAddress)
        {
            if (emailAddress == null)
                return BadRequest();

            if (emailAddress.Type == string.Empty || emailAddress.Email == string.Empty)
            {
                ModelState.AddModelError("Type/Email", "The type and email shouldn't be empty");
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var emailToUpdate = _emailAddressRepository.GetEmailAddressById(emailAddress.EmailAddressId);

            if (emailToUpdate == null)
                return NotFound();

            _emailAddressRepository.UpdateEmailAddress(emailAddress);

            return NoContent();
        }
        
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EmailAddress emailAddress)
        {
            if (emailAddress == null)
                return BadRequest();

            if (emailAddress.Type == string.Empty || emailAddress.Email == string.Empty)
            {
                ModelState.AddModelError("Type/Email", "The type and email shouldn't be empty");
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var knownEmailAddress = await _emailAddressRepository.GetEmailAddressById(emailAddress.EmailAddressId);

            if (knownEmailAddress != null)
                return new StatusCodeResult((int)HttpStatusCode.Conflict);

            var addedEmailAddress = await _emailAddressRepository.AddEmailAddress(emailAddress);

            return Ok(addedEmailAddress);
        }
    }
}