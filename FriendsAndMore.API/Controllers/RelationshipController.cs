using System.Net;
using System.Threading.Tasks;
using FriendsAndMore.DataAccess.Entities;
using FriendsAndMore.DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FriendsAndMore.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RelationshipController : Controller
    {
        private readonly IRelationshipRepository _relationshipRepository;

        public RelationshipController(IRelationshipRepository relationshipRepository)
        {
            _relationshipRepository = relationshipRepository;
        }
        
        [HttpGet("{id}")]
        public async Task<Relationship> Get(int id)
        {
            return await _relationshipRepository.GetRelationshipById(id);
        }
        
        [HttpPut]
        public IActionResult Update([FromBody] Relationship relationship)
        {
            if (relationship == null)
                return BadRequest();

            if (relationship.Type == string.Empty || relationship.Person == string.Empty)
            {
                ModelState.AddModelError("Type/Person", "The type and person shouldn't be empty");
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var relationshipToUpdate = _relationshipRepository.GetRelationshipById(relationship.Id);

            if (relationshipToUpdate == null)
                return NotFound();

            _relationshipRepository.UpdateRelationship(relationship);

            return NoContent();
        }
        
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Relationship relationship)
        {
            if (relationship == null)
                return BadRequest();

            if (relationship.Type == string.Empty || relationship.Person == string.Empty)
            {
                ModelState.AddModelError("Type/Person", "The type and person shouldn't be empty");
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var knownRelationship = await _relationshipRepository.GetRelationshipById(relationship.Id);

            if (knownRelationship != null)
                return new StatusCodeResult((int)HttpStatusCode.Conflict);

            var addedRelationship = await _relationshipRepository.AddRelationship(relationship);

            return Ok(addedRelationship);
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            await _relationshipRepository.DeleteRelationship(id);

            return NoContent();
        }
    }
}