using Microsoft.AspNetCore.Mvc;
using PersonContact.Api.Entities;
using PersonContact.Api.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonContact.Api.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class ReportController
    {
        private readonly PersonContactDbContext _context;
        public ReportController(PersonContactDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public Task Handle()
        {
            // Toplam Kişi Sayısı 
            var reportDetail = _context.Contacts.GroupBy(x => x.Konum).Select(x => new
            {
                location = x.Key,
                totalPeople = x.Count(),
            });

            //O konumda bulunan toplam telefon numarası
            var reportDetail2 = _context.Contacts.Where(x => x.TelephoneNumber != null).GroupBy(x => x.Konum).Select(x => new { location = x.Key, totalNumber = x.Count() });

            return Task.CompletedTask;
        }
    
    }
}
