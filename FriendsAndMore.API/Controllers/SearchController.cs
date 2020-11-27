using System.Collections.Generic;
using System.Threading.Tasks;
using FriendsAndMore.DataAccess.Entities;
using FriendsAndMore.DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FriendsAndMore.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SearchController : Controller
    {
        private readonly IContactRepository _contactRepository;

        public SearchController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }
        
        [HttpGet("{query}")]
        public async Task<IEnumerable<Contact>> Get(string query)
        {
            return await _contactRepository.SearchContacts(query);
        }
    }
}