using System;
using System.Net;
using System.Threading.Tasks;
using FriendsAndMore.DataAccess.Entities;
using FriendsAndMore.DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FriendsAndMore.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatusUpdateController : Controller
    {
        private readonly IStatusUpdateRepository _statusUpdateRepository;

        public StatusUpdateController(IStatusUpdateRepository statusUpdateRepository)
        {
            _statusUpdateRepository = statusUpdateRepository;
        }
        
        [HttpGet("{id}")]
        public async Task<StatusUpdate> Get(int id)
        {
            return await _statusUpdateRepository.GetStatusUpdateById(id);
        }
        
        [HttpPut]
        public IActionResult Update([FromBody] StatusUpdate statusUpdate)
        {
            if (statusUpdate == null)
                return BadRequest();

            if (statusUpdate.Created == DateTime.MinValue || statusUpdate.StatusText == string.Empty)
            {
                ModelState.AddModelError("Created/Text", "The text and creation date shouldn't be empty");
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var statusUpdateToUpdate = _statusUpdateRepository.GetStatusUpdateById(statusUpdate.Id);

            if (statusUpdateToUpdate == null)
                return NotFound();

            _statusUpdateRepository.UpdateStatusUpdate(statusUpdate);

            return NoContent();
        }
        
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] StatusUpdate statusUpdate)
        {
            if (statusUpdate == null)
                return BadRequest();

            if (statusUpdate.Created == DateTime.MinValue || statusUpdate.StatusText == string.Empty)
            {
                ModelState.AddModelError("Created/Text", "The text and creation date shouldn't be empty");
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var knownStatusUpdate = await _statusUpdateRepository.GetStatusUpdateById(statusUpdate.Id);

            if (knownStatusUpdate != null)
                return new StatusCodeResult((int)HttpStatusCode.Conflict);

            var addedStatusUpdate = await _statusUpdateRepository.AddStatusUpdate(statusUpdate);

            return Ok(addedStatusUpdate);
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            await _statusUpdateRepository.DeleteStatusUpdate(id);

            return NoContent();
        }
    }
}