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
    public class LicenseClassesConfiguration : BaseEntityConfiguration<LicenseClasses,int>
    {
        public override void Configure(EntityTypeBuilder<LicenseClasses> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.ClassName)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(p => p.ClassDescription)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(p => p.MinimumAllowedAge)
                .IsRequired()
                .HasColumnType("tinyint");

            builder.Property(p => p.DefaultValidityLength)
                .IsRequired()
                .HasColumnType("tinyint");

            builder.OwnsOne(x => x.ClassFees, money =>
            {
                money.Property(m => m.Amount)
                    .HasColumnName("ClassFees")
                    .HasPrecision(18, 2)
                    .IsRequired();

                money.Property(m => m.Currency)
                    .HasMaxLength(3)
                    .IsRequired()
                    .HasDefaultValue("USD");
            });

            builder.ToTable("LicenseClasses");
        }
    }
}
