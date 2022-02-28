using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonContact.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonContact.Api.Infrastructure.Mapping
{
    public class PersonMapping : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(p => p.Id); //Primary key olarak ID parametresi atandı kendisi zaten Guid olarak tanımlandığı için identity olarak özellik vermedim.

            builder.Property(p => p.Id).IsRequired(); //ID ' nin boş geçilemeyeceğini söyledim.

            //SQLServer'da kişinin adı , soyadı ve şirket bilgilerinin boş geçilemez olduğu ve SQL ' de tutulacağı tipi belirttim.(Nvarchar yapmanın nedeni unicode olarak kullanılmasıdır. )

            builder.Property(p => p.PersonName).IsRequired().HasMaxLength(25).HasColumnType("nvarchar");

            builder.Property(p => p.PersonSurname).IsRequired().HasMaxLength(50).HasColumnType("nvarchar");

            builder.Property(p => p.CompanyName).IsRequired().HasMaxLength(100).HasColumnType("nvarchar");

            builder.HasMany(p => p.Contacts)
                .WithOne(p => p.Person)
                .HasForeignKey(p => p.PersonelId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
