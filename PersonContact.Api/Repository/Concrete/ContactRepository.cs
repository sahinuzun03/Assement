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

        //Kişiye ait olan iletişim bilgilerinin eklenmesi
        public void AddContact(Guid id, Contact contact) 
        {
            contact.PersonelId = id;
            _context.Contacts.Add(contact);
        }

        //İletişim bilgisinin DB'den silinmesi için.
        public void DeleteContact(Guid contactId)
        {
            var deleteContact = _context.Contacts.Find(contactId);
            _context.Contacts.Remove(deleteContact);
        }

        //Kişiye ait bütün iletişim bilgilerinin getirilmesi için.
        public async Task<ActionResult<IEnumerable<Contact>>> GetAllContact(Guid personId)
        {
            return await _context.Contacts.Where(c => c.PersonelId == personId).ToListAsync();
        }

        //Yapılan değişikliklerin kaydedilmesi için.
        public async Task<bool> SaveChanges()
        {
            return (await _context.SaveChangesAsync() > 0);
        }
    }
}
