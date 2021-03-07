using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonsApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsApp.Persistence.Configurations
{
    public class GenderConfiguration : IEntityTypeConfiguration<Gender>
    {
        public void Configure(EntityTypeBuilder<Gender> builder)
        {
            builder.Property(d => d.Name).IsRequired().HasMaxLength(50);
        }
    }
}
