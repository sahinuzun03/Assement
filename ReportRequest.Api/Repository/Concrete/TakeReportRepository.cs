using Microsoft.AspNetCore.Mvc;
using ReportRequest.Api.Entities;
using ReportRequest.Api.Infrastructure.Context;
using ReportRequest.Api.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReportRequest.Api.Repository.Concrete
{
    public class TakeReportRepository : ITakeReportRepository
    {
        private readonly ReportRequestDbContext _context;
        public TakeReportRepository(ReportRequestDbContext context)
        {
            _context = context;
        }

        //Rapor'u database'e eklemek için yazılmıştır.
        public void AddReport(ReportDetail reportDetail)
        {
            _context.ReportDetails.AddAsync(reportDetail);
        }

        //Database'de bulunan rapor bilgisinin getirilmesi
        public async Task<ActionResult<ReportDetail>> GetReport(Guid id)
        {
            return await _context.ReportDetails.FindAsync(id);
        }

        //Database'e kayıt edebilmek için yazılmıştır.SaveChanges yapılmazsa AddReport yapılsa dahi veri database'e gönderilmez.
        public async Task<bool> SaveChanges()
        {
            return (await _context.SaveChangesAsync() > 0);
        }

        public void Update(ReportDetail reportDetail)
        {
            _context.ReportDetails.Update(reportDetail);
        }

        public ReportDetail GetReports(Guid id)
        {
            return _context.ReportDetails.Find(id);
            
        }

        
    }
}
