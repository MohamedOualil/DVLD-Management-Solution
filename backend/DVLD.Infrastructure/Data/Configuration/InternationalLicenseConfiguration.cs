using DVLD.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Infrastructure.Data.Configuration
{
    public class InternationalLicenseConfiguration : BaseEntityConfiguration<InternationalLicense>
    {
        public override void Configure(EntityTypeBuilder<InternationalLicense> builder)
        {
            base.Configure(builder);

            builder.HasIndex(i => i.ApplicationId)
                .IsUnique()
                .HasDatabaseName("UQ_InternationalLicenses_ApplicationId");

            builder.HasOne(i => i.Application)
                .WithOne()
                .HasForeignKey<InternationalLicense>(i => i.ApplicationId)
                .HasConstraintName("FK_InternationalLicenses_Applications")
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(i => i.LocalLicense)
                .WithMany() 
                .HasForeignKey(i => i.IssuedUsingLocalLicenseId)
                .HasConstraintName("FK_InternationalLicenses_DrivingLicenses")
                .OnDelete(DeleteBehavior.NoAction);


            builder.HasOne(i => i.Driver)
                .WithMany()
                .HasForeignKey(i => i.DriverId)
                .HasConstraintName("FK_InternationalLicenses_Drivers")
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(i => i.CreatedBy)
                .WithMany()
                .HasForeignKey(i => i.CreatedByUserId)
                .HasConstraintName("FK_InternationalLicenses_Users")
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(i => i.IssueReason)
                .HasColumnType("TINYINT")
                .IsRequired()
                .HasConversion<byte>();

            builder.Property(i => i.IssueDate)
                .HasColumnType("DATETIME2")
                .IsRequired()
                .HasDefaultValueSql("SYSUTCDATETIME()")
                .ValueGeneratedOnAdd();

            builder.Property(i => i.ExpirationDate)
                .HasColumnType("DATETIME2")
                .IsRequired();

            builder.Property(i => i.IsActive)
                .IsRequired()
                .HasDefaultValue(true);

            builder.Property(i => i.IsDetained)
                .IsRequired()
                .HasDefaultValue(false);


            builder.ToTable("InternationalLicenses", il =>
            {
                il.HasCheckConstraint("CK_InternationalLicenses_ExpirationDate", "ExpirationDate > IssueDate");
                il.HasCheckConstraint("CK_InternationalLicenses_IssueReason", "IssueReason IN (1, 2, 3, 4)");
            });
        }
    }
}
