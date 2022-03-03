using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PersonContact.Api.Entities;
using PersonContact.Api.Infrastructure.Context;
using PersonContact.Api.Repository.Abstract;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonContact.Api.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class ReportController
    {
        private readonly PersonContactDbContext _context;
        private readonly IContactRepository _contactRepository;
        public ReportController(PersonContactDbContext context, IContactRepository contactRepository)
        {
            _context = context;
            _contactRepository = contactRepository;
        }

        //Rapor'a ait olan id bilgisini aldık ?!!
        [HttpGet("{id}")]
        public async Task<string> GetReport(Guid id)
        {
            //Gelen raporu kuyruguğa gönderiyorum
            var factor = new ConnectionFactory
            {
                Uri = new Uri("amqp://admin:123456@localhost:5672")
            };
            var queueName = id.ToString().ToUpper();
            using var connection = factor.CreateConnection();
            using var channel = connection.CreateModel();
            channel.QueueDeclare(queueName,
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            var totalPeople = _context.Contacts.GroupBy(x => x.Konum).Select(x => new
            {
                location = x.Key,
                totalPeople = x.Count(),
            });

            var message = totalPeople;
            var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));

            channel.BasicPublish("", queueName, null, body);

            return JsonConvert.SerializeObject(message);
        }
    }
}
