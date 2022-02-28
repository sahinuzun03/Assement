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
        public void AddPerson(Person person)
        {
            _context.People.Add(person);
        }

        public void DeletePerson(Guid id)
        {
            var deletedPerson = _context.People.Find(id);
            _context.People.Remove(deletedPerson);
        }

        public Person GetPersonForAddContact(Guid id)
        {
            return _context.People.Find(id);
        }

        public async Task<ActionResult<IEnumerable<Person>>> GetAllPerson()
        {
            return await _context.People.ToListAsync();
        }
        public async Task<ActionResult<Person>> GetPerson(Guid id)
        {
            return await _context.People.FindAsync(id);
        }
        public async Task<bool> SaveChanges()
        {
            return (await _context.SaveChangesAsync() > 0);
        }
    }
}
