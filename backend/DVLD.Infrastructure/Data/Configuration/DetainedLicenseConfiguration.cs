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
    public class DetainedLicenseConfiguration : BaseEntityConfiguration<DetainedLicense,int>
    {
        public override void Configure(EntityTypeBuilder<DetainedLicense> builder)
        {
            base.Configure(builder);

            builder.HasOne(d => d.License)
                .WithMany()
                .HasForeignKey(d => d.LicenseId)
                .OnDelete(DeleteBehavior.Restrict);


            builder.HasOne(d => d.CreatedBy)
                .WithMany()
                .HasForeignKey(d => d.CreatedByUserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(d => d.ReleasedBy)
                .WithMany()
                .HasForeignKey(d => d.ReleasedByUserId)
                .IsRequired(false) 
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(d => d.ReleaseApplication)
                .WithMany()
                .HasForeignKey(d => d.ReleaseApplicationId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            builder.OwnsOne(d => d.FineFees, money =>
            {
                money.Property(m => m.Amount)
                    .HasColumnName("FineFees")
                    .HasPrecision(18, 2)
                    .IsRequired();

                money.Property(m => m.Currency)
                    .HasMaxLength(3)
                    .IsRequired()
                    .HasDefaultValue("USD");
            });

            builder.Property(d => d.DetainDate)
                .IsRequired();

            builder.Property(d => d.IsReleased)
                .IsRequired()
                .HasDefaultValue(false);

            builder.Property(d => d.ReleaseDate)
                .IsRequired(false);

            builder.ToTable("DetainedLicenses");
        }
    }
}
