using ReportRequest.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReportRequest.Api.Repository.Abstract
{
    public interface ITakeReportRepository
    {
        void AddReport(ReportDetail reportDetail);
        Task<bool> SaveChanges();

    }
}
