using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RabbitMQ.Client;
using ReportRequest.Api.Entities;
using ReportRequest.Api.Infrastructure.Context;
using ReportRequest.Api.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportRequest.Api.Controllers
{
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
        public async Task<ActionResult<ReportDetail>> TakeReport(ReportDetail reportDetail)
        {
            reportDetail.ReportStatus = ReportStatus.getReady;

            _report.AddReport(reportDetail);
            await _report.SaveChanges();

            var factor = new ConnectionFactory
            {
                Uri = new Uri("amqp://admin:123456@localhost:5672")
            };

            using var connection = factor.CreateConnection();
            using var channel = connection.CreateModel();
            channel.QueueDeclare("report-queue",
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            var message = new { Name = "ReportRequest" , Message = "Rapor Talep Ediyorum"};
            var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));

            channel.BasicPublish("", "demo-queue", null, body);

            return Ok("Mesaj Gönderildi");
        }
    }
}
