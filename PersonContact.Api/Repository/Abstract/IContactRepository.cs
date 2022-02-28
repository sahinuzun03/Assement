using Microsoft.AspNetCore.Mvc;
using PersonContact.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonContact.Api.Repository.Abstract
{
    public interface IContactRepository
    {
        Task<ActionResult<IEnumerable<Contact>>> GetAllContact(Guid personId); //Seçilen kişiye ait id parametresi gelecektir.
        void AddContact(Guid personId ,Contact contact); //Kişiye ait iletişin bilgisi eklenecek
        void DeleteContact(Guid contactId); // Personele ait kişi bilgilerinin silinmesi için.
        Task<bool> SaveChanges(); //Veri tabanı değişikliklerinin kaydedilmesi
    }
}
