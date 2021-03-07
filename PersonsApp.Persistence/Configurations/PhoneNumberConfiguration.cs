using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonsApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsApp.Persistence.Configurations
{
    public class PhoneNumberConfiguration : IEntityTypeConfiguration<PhoneNumber>
    {
        public void Configure(EntityTypeBuilder<PhoneNumber> builder)
        {
            builder.Property(d => d.Number).IsRequired().HasMaxLength(50);
        }
    }
}
