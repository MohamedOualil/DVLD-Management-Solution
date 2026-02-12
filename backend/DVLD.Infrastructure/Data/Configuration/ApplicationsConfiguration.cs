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
    public class ApplicationsConfiguration : BaseEntityConfiguration<Applications, int>
    {
        public override void Configure(EntityTypeBuilder<Applications> builder)
        {
            base.Configure(builder);

            builder.HasOne(u => u.Person)
                .WithMany()
                .HasForeignKey(p => p.PersonId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(p => p.ApplicationDate)
                .IsRequired();

            builder.HasOne(u => u.ApplicationType)
                .WithMany()
                .HasForeignKey(p => p.ApplicationTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(s => s.Status)
                .IsRequired()
                .HasConversion<short>();

            builder.Property(p => p.LastStatusDate);

            builder.OwnsOne(x => x.PaidFees, money =>
            {
                money.Property(m => m.Amount)
                    .HasColumnName("PaidFees")
                    .HasPrecision(18, 2)
                    .IsRequired();

                money.Property(m => m.Currency)
                    .HasMaxLength(3)
                    .IsRequired()
                    .HasDefaultValue("USD");
            });

            builder.HasOne(u => u.CreatedBy)
                .WithMany()
                .HasForeignKey(p => p.CreatedByUserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(u => u.LastUpdatedBy)
                .WithMany()
                .HasForeignKey(p => p.LastUpdatedByUserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("Applications");

        }
    }
}
