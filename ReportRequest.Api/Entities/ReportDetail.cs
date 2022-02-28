using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReportRequest.Api.Entities
{
    public enum ReportStatus { getReady=1,completed=2}
    public class ReportDetail
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public ReportStatus ReportStatus { get; set; }
        public DateTime ReportDate { get; set; } = DateTime.Now;
    }
}
