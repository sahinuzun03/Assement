using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonContact.Api.Entities
{
    public class Person
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string PersonName { get; set; }
        public string PersonSurname { get; set; }
        public string CompanyName { get; set; }
        public List<Contact> Contacts { get; set; }

        public Person()
        {
            Contacts = new List<Contact>();
        }
    }
}
