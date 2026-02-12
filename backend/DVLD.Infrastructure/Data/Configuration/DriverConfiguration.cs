using DVLD.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Infrastructure.Data.Configuration
{
    public class DriverConfiguration : BaseEntityConfiguration<Driver, int>
    {
        public override void Configure(EntityTypeBuilder<Driver> builder)
        {
            base.Configure(builder);

            builder.HasOne(d => d.Person)
            .WithOne() 
            .HasForeignKey<Driver>(d => d.PersonId)
            .OnDelete(DeleteBehavior.Restrict);


            builder.HasOne(d => d.CreatedBy)
                .WithMany()
                .HasForeignKey(d => d.CreatedByUserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("Drivers");
        }
    }
}
