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
    public class InternationalLicenseConfiguration : BaseEntityConfiguration<InternationalLicense,int>
    {
        public override void Configure(EntityTypeBuilder<InternationalLicense> builder)
        {
            base.Configure(builder);

            builder.HasOne(x => x.Application)
                .WithMany()
                .HasForeignKey(x => x.ApplicationId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.LocalLicense)
                .WithMany()
                .HasForeignKey(x => x.IssuedUsingLocalLicenseId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Driver)
                .WithMany()
                .HasForeignKey(x => x.DriverId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(e => e.IssueReason)
                .IsRequired()
                .HasConversion<short>();

            builder.HasOne(u => u.CreatedBy)
                .WithMany()
                .HasForeignKey(p => p.CreatedByUserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.IssueDate).IsRequired();
            builder.Property(x => x.ExpirationDate).IsRequired();
            builder.Property(x => x.IsActive).IsRequired().HasDefaultValue(true);
            builder.Property(x => x.IsDetained).IsRequired().HasDefaultValue(false);

            builder.ToTable("InternationalLicenses");
        }
    }
}
