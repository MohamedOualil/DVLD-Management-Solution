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
    public class LicenseClassesConfiguration : BaseEntityConfiguration<LicenseClass>
    {
        public override void Configure(EntityTypeBuilder<LicenseClass> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.ClassName)
                .IsRequired()
                .HasMaxLength(100);

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

                money.Ignore(m => m.Currency);
            });

            builder.ToTable("LicenseClasses", l =>
            {
                l.HasCheckConstraint("CHK_LicenseClasses_ClassFees", "ClassFees >= 0");

                l.HasCheckConstraint("CHK_LicenseClasses_Validity", "DefaultValidityLength > 0");

                l.HasCheckConstraint("CHK_LicenseClasses_Age", "MinimumAllowedAge > 0");
            });
        }
    }
}
