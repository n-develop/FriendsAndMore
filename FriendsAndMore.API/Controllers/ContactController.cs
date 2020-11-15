using System.Collections.Generic;
using System.Threading.Tasks;
using FriendsAndMore.DataAccess.Entities;
using FriendsAndMore.DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FriendsAndMore.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController : Controller
    {
        private readonly ILogger<ContactController> _logger;
        private readonly IContactRepository _contactRepository;

        public ContactController(ILogger<ContactController> logger, IContactRepository contactRepository)
        {
            _logger = logger;
            _contactRepository = contactRepository;
        }
        
        [HttpGet]
        public async Task<IEnumerable<Contact>> Get()
        {
            return await _contactRepository.GetContacts();
        }
        
        [HttpGet("{id}")]
        public async Task<Contact> Get(int id)
        {
            return await _contactRepository.GetContactById(id);
        }
        
        [HttpPut]
        public IActionResult Update([FromBody] Contact contact)
        {
            if (contact == null)
                return BadRequest();

            if (contact.FirstName == string.Empty || contact.LastName == string.Empty)
            {
                ModelState.AddModelError("Name/FirstName", "The name or first name shouldn't be empty");
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var contactToUpdate = _contactRepository.GetContactById(contact.ContactId);

            if (contactToUpdate == null)
                return NotFound();

            _contactRepository.UpdateContact(contact);

            return NoContent(); //success
        }
    }
}