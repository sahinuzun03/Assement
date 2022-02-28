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
        public void AddReport(ReportDetail reportDetail)
        {
            _context.ReportDetails.AddAsync(reportDetail);
        }

        public async Task<bool> SaveChanges()
        {
            return (await _context.SaveChangesAsync() > 0);
        }
    }
}
