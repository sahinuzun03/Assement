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
    public class PersonRepository : IPersonRepository
    {

        private readonly PersonContactDbContext _context;
        public PersonRepository(PersonContactDbContext context)
        {
            _context = context;
        }

        //Kişi eklemek için yazılmıştır.DB'ye kişi ekleme
        public void AddPerson(Person person)
        {
            _context.People.Add(person);
        }

        //DB ' de bulunan kişini silinmesi.
        public void DeletePerson(Guid id)
        {
            var deletedPerson = _context.People.Find(id);
            _context.People.Remove(deletedPerson);
        }

        //Kişinin getirilmesi
        public Person GetPersonForAddContact(Guid id)
        {
            return _context.People.Find(id);
        }

        //Sistemde kayıtlı olan kişilerin listelenmesi
        public async Task<ActionResult<IEnumerable<Person>>> GetAllPerson()
        {
            return await _context.People.ToListAsync();
        }
        //DB ' de bulunan kişinin getirilmesi
        public async Task<ActionResult<Person>> GetPerson(Guid id)
        {
            return await _context.People.FindAsync(id);
        }

        //Değişikliklerin kaydedilmesi
        public async Task<bool> SaveChanges()
        {
            return (await _context.SaveChangesAsync() > 0);
        }
    }
}
