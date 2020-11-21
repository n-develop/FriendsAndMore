using System.Net;
using System.Threading.Tasks;
using FriendsAndMore.DataAccess.Entities;
using FriendsAndMore.DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FriendsAndMore.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TelephoneNumberController : Controller
    {
        private readonly ITelephoneNumberRepository _telephoneNumberRepository;

        public TelephoneNumberController(ITelephoneNumberRepository telephoneNumberRepository)
        {
            _telephoneNumberRepository = telephoneNumberRepository;
        }
        
        [HttpGet("{id}")]
        public async Task<TelephoneNumber> Get(int id)
        {
            return await _telephoneNumberRepository.GetTelephoneNumberById(id);
        }
        
        [HttpPut]
        public IActionResult Update([FromBody] TelephoneNumber telephoneNumber)
        {
            if (telephoneNumber == null)
                return BadRequest();

            if (telephoneNumber.Type == string.Empty || telephoneNumber.Telephone == string.Empty)
            {
                ModelState.AddModelError("Type/Telephone", "The type and number shouldn't be empty");
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var telephoneNumberToUpdate = _telephoneNumberRepository.GetTelephoneNumberById(telephoneNumber.Id);

            if (telephoneNumberToUpdate == null)
                return NotFound();

            _telephoneNumberRepository.UpdateTelephoneNumber(telephoneNumber);

            return NoContent();
        }
        
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TelephoneNumber telephoneNumber)
        {
            if (telephoneNumber == null)
                return BadRequest();

            if (telephoneNumber.Type == string.Empty || telephoneNumber.Telephone == string.Empty)
            {
                ModelState.AddModelError("Type/Telephone", "The type and number shouldn't be empty");
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var knownEntity = await _telephoneNumberRepository.GetTelephoneNumberById(telephoneNumber.Id);

            if (knownEntity != null)
                return new StatusCodeResult((int)HttpStatusCode.Conflict);

            var addedEntity = await _telephoneNumberRepository.AddTelephoneNumber(telephoneNumber);

            return Ok(addedEntity);
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            await _telephoneNumberRepository.DeleteTelephoneNumber(id);

            return NoContent();
        }
    }
}