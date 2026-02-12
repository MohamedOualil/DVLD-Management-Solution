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
    public class LicenseConfiguration : BaseEntityConfiguration<License,int>
    {
        public override void Configure(EntityTypeBuilder<License> builder)
        {
            base.Configure(builder);

            builder.HasOne(x => x.Applications)
                .WithMany()
                .HasForeignKey(x => x.ApplicationId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(d => d.Driver)
                .WithMany()
                .HasForeignKey(d => d.DriverId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(l => l.LicenseClass)
                .WithMany()
                .HasForeignKey(l => l.LicenseClassId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(d => d.IssueDate)
                .IsRequired();
            builder.Property(d => d.ExpirationDate)
                .IsRequired();

            builder.Property(n => n.Notes)
                .HasMaxLength(500);

            builder.Property(p => p.IsActive)
                .IsRequired()
                .HasDefaultValue(true);

            builder.Property(e => e.IssueReason)
                .IsRequired()
                .HasConversion<short>();

            builder.OwnsOne(l => l.PaidFees, money =>
            {
                money.Property(m => m.Amount).HasColumnName("PaidFees").HasPrecision(18, 2);
                money.Property(m => m.Currency).HasMaxLength(3).HasDefaultValue("USD");
            });

            builder.HasOne(u => u.CreatedBy)
                .WithMany()
                .HasForeignKey(p => p.CreatedByUserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("Licenses");
        }
    }
}
