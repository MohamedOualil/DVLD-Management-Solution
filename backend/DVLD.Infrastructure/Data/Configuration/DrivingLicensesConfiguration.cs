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
    public class DrivingLicensesConfiguration : BaseEntityConfiguration<DrivingLicense>
    {
        public override void Configure(EntityTypeBuilder<DrivingLicense> builder)
        {
            base.Configure(builder);

            builder.HasIndex(l => l.ApplicationId)
                .IsUnique()
                .HasDatabaseName("UQ_DrivingLicenses_ApplicationId");

            builder.HasOne(l => l.Application)
                .WithOne()
                .HasForeignKey<DrivingLicense>(l => l.ApplicationId)
                .HasConstraintName("FK_DrivingLicenses_Applications")
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(l => l.Driver)
                .WithMany() // A Driver can have many licenses 
                .HasForeignKey(l => l.DriverId)
                .HasConstraintName("FK_DrivingLicenses_Drivers")
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(l => l.LicenseClass)
                .WithMany()
                .HasForeignKey(l => l.LicenseClassId)
                .HasConstraintName("FK_DrivingLicenses_LicenseClasses")
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(l => l.CreatedBy)
                .WithMany()
                .HasForeignKey(l => l.CreatedByUserId)
                .HasConstraintName("FK_DrivingLicenses_Users")
                .OnDelete(DeleteBehavior.NoAction);

            builder.OwnsOne(x => x.PaidFees, money =>
            {
                money.Property(m => m.Amount)
                    .HasColumnName("PaidFees")
                    .HasPrecision(18, 2)
                    .IsRequired();

                money.Ignore(m => m.Currency);
            });

            builder.Ignore(l => l.LicenseClassEnum);

            builder.Property(l => l.IssueReason)
                .HasColumnType("TINYINT")
                .IsRequired()
                .HasConversion<byte>();

            builder.Property(l => l.IssueDate)
                .HasColumnType("DATETIME2")
                .IsRequired()
                .HasDefaultValueSql("SYSUTCDATETIME()")
                .ValueGeneratedOnAdd();

            builder.Property(l => l.IsActive)
                .IsRequired()
                .HasDefaultValue(true);

            builder.Property(l => l.IsDetained)
                .IsRequired()
                .HasDefaultValue(false);

            builder.Property(l => l.ExpirationDate)
                .HasColumnType("DATETIME2")
                .IsRequired();


            builder.Property(l => l.Notes)
                .HasColumnType("NVARCHAR(MAX)")
                .HasMaxLength(500) 
                .IsRequired(false);

            builder.ToTable("DrivingLicenses", dl =>
            {
                dl.HasCheckConstraint("CK_DrivingLicenses_Dates", "ExpirationDate > IssueDate");
                dl.HasCheckConstraint("CK_DrivingLicenses_IssueReason", "IssueReason IN (1, 2, 3, 4)");
                dl.HasCheckConstraint("CK_DrivingLicenses_PaidFees", "PaidFees >= 0");
            });
        }
    }
}
