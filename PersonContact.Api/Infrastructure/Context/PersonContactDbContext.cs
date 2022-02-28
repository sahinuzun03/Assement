using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PersonContact.Api.Entities;
using PersonContact.Api.Infrastructure.Mapping;

namespace PersonContact.Api.Infrastructure.Context
{
    public class PersonContactDbContext : DbContext
    {
        public PersonContactDbContext(DbContextOptions<PersonContactDbContext> options) : base(options)
        {

        }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Person> People { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ContactMapping())
                .ApplyConfiguration(new PersonMapping());
        }
    }
}
