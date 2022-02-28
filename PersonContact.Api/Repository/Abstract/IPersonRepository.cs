using Microsoft.AspNetCore.Mvc;
using PersonContact.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonContact.Api.Repository.Abstract
{
    public interface IPersonRepository 
    {
        Task<ActionResult<IEnumerable<Person>>> GetAllPerson(); //Database'de buluna bütün kişilerin getirilmesi
        Task<ActionResult<Person>> GetPerson(Guid id); // Sadece 1 kişinin getirilmesi
        void AddPerson(Person person); //Kişi eklemesi
        void DeletePerson(Guid id); //Kişi ekleme
        Task<bool> SaveChanges(); //Veri tabanı değişikliklerinin kaydedilmesi
        Person GetPersonForAddContact(Guid id);
    }
}
