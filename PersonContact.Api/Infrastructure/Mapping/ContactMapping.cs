using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonContact.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonContact.Api.Infrastructure.Mapping
{
    public class ContactMapping : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id).IsRequired();

            builder.Property(c => c.EmailAdress).IsRequired().HasColumnType("nvarchar").HasMaxLength(200);

            builder.Property(c => c.InformationContent).IsRequired().HasColumnType("nvarchar").HasMaxLength(200);

            builder.Property(c => c.Konum).IsRequired().HasColumnType("nvarchar").HasMaxLength(200);

            builder.Property(c => c.TelephoneNumber).IsRequired().HasColumnType("nvarchar").HasMaxLength(200);
        }
    }
}
