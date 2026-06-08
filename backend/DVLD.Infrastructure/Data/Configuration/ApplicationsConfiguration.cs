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
    public class ApplicationsConfiguration : BaseEntityConfiguration<Domain.Entities.Application>
    {
        public override void Configure(EntityTypeBuilder<Domain.Entities.Application> builder)
        {
            base.Configure(builder);

            builder.HasOne(u => u.Person)
                .WithMany()
                .HasForeignKey(p => p.PersonId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(p => p.ApplicationDate)
                .HasDefaultValueSql("SYSUTCDATETIME()")
                .ValueGeneratedOnAdd();

            builder.HasOne(u => u.ApplicationType)
                .WithMany()
                .HasForeignKey(u => u.ApplicationTypeId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(s => s.Status)
                .HasColumnType("TINYINT")
                .IsRequired()
                .HasConversion<byte>();

            builder.Property(p => p.LastStatusDate)
                .IsRequired()
                .HasDefaultValueSql("SYSUTCDATETIME()") 
                .ValueGeneratedOnAdd();

            builder.OwnsOne(x => x.PaidFees, money =>
            {
                money.Property(m => m.Amount)
                    .HasColumnName("PaidFees")
                    .HasPrecision(18, 2)
                    .IsRequired();

                money.Ignore(m => m.Currency);
            });

            builder.HasOne(u => u.CreatedBy)
                .WithMany()
                .HasForeignKey(p => p.CreatedByUserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(u => u.LastUpdatedBy)
                .WithMany()
                .HasForeignKey(p => p.LastUpdatedByUserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.ToTable("Applications",a =>
            {
                a.HasCheckConstraint("CK_Applications_Status", "Status IN (1, 2, 3)");

                a.HasCheckConstraint("CK_Applications_PaidFees", "PaidFees >= 0");
            });

        }
    }
}
