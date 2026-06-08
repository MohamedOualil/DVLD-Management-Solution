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
    public class DriverConfiguration : BaseEntityConfiguration<Driver>
    {
        public override void Configure(EntityTypeBuilder<Driver> builder)
        {
            base.Configure(builder);

            builder.HasOne(d => d.Person)
            .WithOne() 
            .HasForeignKey<Driver>(d => d.PersonId)
            .OnDelete(DeleteBehavior.NoAction);


            builder.HasOne(d => d.CreatedBy)
                .WithMany()
                .HasForeignKey(d => d.CreatedByUserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(d => d.CreateAt)
               .HasDefaultValueSql("SYSUTCDATETIME()")
               .ValueGeneratedOnAdd();

            builder.HasIndex(d => d.PersonId).IsUnique()
                .HasDatabaseName("UQ_Drivers_PersonId");

            builder.ToTable("Drivers");
        }
    }
}
