using DVLD.Domain.Common;
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
    public class LocalDrivingLicenseApplicationConfiguration : BaseEntityConfiguration<LocalDrivingLicenseApplication>
    {
        public override void Configure(EntityTypeBuilder<LocalDrivingLicenseApplication> builder)
        {
            base.Configure(builder);

            builder.HasIndex(l => l.ApplicationId)
                .IsUnique()
                .HasDatabaseName("UQ_LocalDrivingLicenseApplications_ApplicationId");

            builder.HasOne(l => l.Application)
                .WithOne() 
                .HasForeignKey<LocalDrivingLicenseApplication>(l => l.ApplicationId)
                .HasConstraintName("FK_LocalDrivingLicenseApplications_Applications")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(l => l.LicenseClass)
                .WithMany()
                .HasForeignKey(l => l.LicenseClassId)
                .HasConstraintName("FK_LocalDrivingLicenseApplications_LicenseClasses")
                .OnDelete(DeleteBehavior.NoAction);


            builder.ToTable("LocalDrivingLicenseApplications");
        }
    }
}
