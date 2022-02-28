using Microsoft.AspNetCore.Mvc;
using PersonContact.Api.Entities;
using PersonContact.Api.Infrastructure.Context;
using PersonContact.Api.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonContact.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController : Controller
    {
        private readonly IContactRepository _contactRepository;

        private readonly PersonContactDbContext _context;
        public ContactController(IContactRepository contactRepository, PersonContactDbContext context)
        {
            _contactRepository = contactRepository;
            _context = context;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Contact>>> GetAllContact([FromRoute] Guid id)
        {
            return await _contactRepository.GetAllContact(id);
        }

        [HttpPost("{personId}")]
        public async Task<ActionResult<Contact>> PostContact([FromRoute] Guid personId, [FromBody] Contact contact)
        {
            _contactRepository.AddContact(personId, contact);
            await _contactRepository.SaveChanges();

            return CreatedAtAction("GetAllContact", new { id = personId }, contact);
        }

        [HttpDelete("{contactId}")]
        public async Task<ActionResult<Contact>> DeleteContact([FromRoute] Guid contactId)
        {
            _contactRepository.DeleteContact(contactId);
            await _contactRepository.SaveChanges();

            return Ok();
        }


    }
}
