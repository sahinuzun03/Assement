using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReportRequest.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReportRequest.Api.Infrastructure.Mapping
{
    public class ReportDetailsMapping : IEntityTypeConfiguration<ReportDetail>
    {
        public void Configure(EntityTypeBuilder<ReportDetail> builder)
        {
            builder.HasKey(rd => rd.Id);

            builder.Property(rd => rd.Id).IsRequired();

            builder.Property(rd => rd.ReportDate).HasColumnType("date").IsRequired();
        }
    }
}
