using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonsApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsApp.Persistence.Configurations
{
    public class PersonConnectionConfiguration : IEntityTypeConfiguration<PersonConnection>
    {
        public void Configure(EntityTypeBuilder<PersonConnection> builder)
        {
            builder.HasOne(d => d.ConnectedPerson).WithMany().HasForeignKey(d => d.ConnectedPersonId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(d => d.Person).WithMany(x => x.PersonConections).HasForeignKey(d => d.PersonId);
        }
    }
}
