using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonContact.Api.Entities;
using PersonContact.Api.Infrastructure.Context;
using PersonContact.Api.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonContact.Api.Repository.Concrete
{
    public class ContactRepository : IContactRepository
    {
        private readonly PersonContactDbContext _context;
        public ContactRepository(PersonContactDbContext context)
        {
            _context = context;
        }
        public void AddContact(Guid id, Contact contact) //Bir kişiye ait iletişim bilgilerini eklenmesi için.
        {
            contact.PersonelId = id;
            _context.Contacts.Add(contact);
        }
        public void DeleteContact(Guid contactId)
        {
            var deleteContact = _context.Contacts.Find(contactId);
            _context.Contacts.Remove(deleteContact);
        }

        public async Task<ActionResult<IEnumerable<Contact>>> GetAllContact(Guid personId)
        {
            return await _context.Contacts.Where(c => c.PersonelId == personId).ToListAsync();
        }
        public async Task<bool> SaveChanges()
        {
            return (await _context.SaveChangesAsync() > 0);
        }
    }
}
