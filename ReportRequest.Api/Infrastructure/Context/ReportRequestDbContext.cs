using Microsoft.EntityFrameworkCore;
using ReportRequest.Api.Entities;
using ReportRequest.Api.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReportRequest.Api.Infrastructure.Context
{
    public class ReportRequestDbContext : DbContext
    {
        public ReportRequestDbContext(DbContextOptions<ReportRequestDbContext> options) : base(options)
        {

        }

        public DbSet<ReportDetail> ReportDetails { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ReportDetailsMapping());
        }


    }
}
