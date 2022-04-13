using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using ReportRequest.Api.Entities;
using ReportRequest.Api.Infrastructure.Context;
using ReportRequest.Api.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ReportRequest.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportRequestController : Controller
    {
        private readonly ReportRequestDbContext _context;
        private readonly ITakeReportRepository _report;
        public ReportRequestController(ReportRequestDbContext context, ITakeReportRepository report)
        {
            _context = context;
            _report = report;
        }

        [HttpPost]
        public async Task<ActionResult<ReportDetail>> TakeReport()
        {
            //Post metot her tetiklendiğinde 1 tane rapor detayı oluşturuyorum.
            ReportDetail reportDetail = new ReportDetail();
            //Rapor oluşturuldu ve oluşturulan rapor database'e kaydedildi.
            _report.AddReport(reportDetail);
            await _report.SaveChanges();

            //Kuyruk ismini oluşan rapordetayının id parametresi olarak aldım.
            var queueName = reportDetail.Id.ToString().ToUpper();
            

            //PersonContactApi'de bulunan Report ' u tetikliyorum böylelikle rapora ait bilgiler kuyruğa göndermiş ve buradan okunmasını sağlayacapım.
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44349/");
                var responseTask = client.GetAsync("api/Report/"+ queueName);
                responseTask.Wait();

                var factory = new ConnectionFactory
                {
                    Uri = new Uri("amqp://admin:123456@localhost:5672")
                };

                using var connection = factory.CreateConnection();
                using var channel = connection.CreateModel();
                /*
                 * İlk parametre kuyruk ismimizi belirtmek için kullanılır.
                 * Durable parametre ise kuyruğa gönderilen mesaj otomatik olarak silinecek mi ?
                 * Exclusive parametre kuyruk farklı connectionlarda kullanılabilir onu belirliyoruz.
                 * Autodelete parametre bu parametre ile kuyrukta yer alan veri consumer'a ulaştığında silinmesi ayarlanması sağlar.
                 */
                channel.QueueDeclare(queueName,
                    durable: true,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null);

                //Consumer event ile gönderileb mesajın okunması işlemlerini gerçekleştiriyorum.
                EventingBasicConsumer consumer = new EventingBasicConsumer(channel);
                channel.BasicConsume(queueName, false, consumer);
                consumer.Received += (sender, e) =>
                {
                    var body = e.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    var message2 = JsonConvert.DeserializeObject(message);

                    // Bu aşağıdaki kod göndermiş olduğum json nesneyi çevirmeye yarar.
                    //var x = JsonConvert.DeserializeObject(message);
                    //Burada gelen mesajı veritabanında string olarak kaydettim ve raporun statüsünü completed'a çektim.
                    //Raporun güncellenmesi ve kaydedilmesi.
                    var report = _report.GetReports(reportDetail.Id);
                    report.ReportStatus = ReportStatus.completed;
                    report.ReportResult = message.ToString();
                    _report.Update(report);
                    _report.SaveChanges();
                };

                //Kuyruktan gelen bilgilerle beraber raporu database kaydediyorum.
            }
            //Son olarakta raporu getiriyorum.
            return CreatedAtAction("GetReport", new { id = reportDetail.Id }, reportDetail); //Gelen modeli tekrardan kullanıcıya gösterdim.
        }

        //id parametresini alarak raporun görüntülenmesini sağladım.
        [HttpGet("{id}")]
        public async Task<ActionResult<ReportDetail>> GetReport([FromRoute] Guid id)
        {
            return await _report.GetReport(id);
        }
    }
}
