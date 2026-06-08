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
    public class DetainedLicenseConfiguration : BaseEntityConfiguration<DetainedLicense>
    {
        public override void Configure(EntityTypeBuilder<DetainedLicense> builder)
        {
            base.Configure(builder);

            builder.HasIndex(d => d.ReleaseApplicationId)
                .IsUnique()
                .HasFilter("[ReleaseApplicationId] IS NOT NULL") 
                .HasDatabaseName("UQ_DetainedLicenses_ReleaseApplicationId");

            builder.HasOne(d => d.ReleaseApplication)
                .WithOne()
                .HasForeignKey<DetainedLicense>(d => d.ReleaseApplicationId)
                .HasConstraintName("FK_DetainedLicenses_Applications")
                .IsRequired(false) 
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(d => d.License)
                .WithMany()
                .HasForeignKey(d => d.LicenseId)
                .HasConstraintName("FK_DetainedLicenses_DrivingLicenses")
                .OnDelete(DeleteBehavior.NoAction);


            builder.HasOne(d => d.CreatedBy)
                .WithMany()
                .HasForeignKey(d => d.CreatedByUserId)
                .HasConstraintName("FK_DetainedLicenses_CreatedBy_Users")
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(d => d.ReleasedBy)
                .WithMany()
                .HasForeignKey(d => d.ReleasedByUserId)
                .HasConstraintName("FK_DetainedLicenses_ReleasedBy_Users")
                .IsRequired(false) 
                .OnDelete(DeleteBehavior.NoAction);

            builder.OwnsOne(x => x.FineFees, money =>
            {
                money.Property(m => m.Amount)
                    .HasColumnName("PaidFees") // Maps C# 'FineFees' to SQL 'PaidFees'
                    .HasPrecision(18, 2)
                    .IsRequired();

                money.Ignore(m => m.Currency);
            });

            builder.Property(d => d.DetainDate)
                .HasColumnType("DATETIME2")
                .IsRequired()
                .HasDefaultValueSql("SYSUTCDATETIME()")
                .ValueGeneratedOnAdd();


            builder.Property(d => d.ReleaseDate)
                .HasColumnType("DATETIME2")
                .IsRequired(false);

            builder.Property(d => d.IsReleased)
                .IsRequired()
                .HasDefaultValue(false);

            builder.ToTable("DetainedLicenses", dl =>
            {
                dl.HasCheckConstraint("CK_DetainedLicenses_ReleaseDate", "ReleaseDate > DetainDate");
                dl.HasCheckConstraint("CK_DetainedLicenses_PaidFees", "PaidFees >= 0");
            });
        }
    }
}
