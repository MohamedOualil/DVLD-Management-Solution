using DVLD.Domain.Entities;
using DVLD.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Infrastructure.Data.Configuration
{
    public class ApplicationTypesConfiguration : BaseEntityConfiguration<ApplicationType>
    {
        public override void Configure(EntityTypeBuilder<ApplicationType> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.ApplicationTypeTitle)
                .IsRequired()
                .HasMaxLength(100);

            builder.OwnsOne(x => x.ApplicationFees, money =>
            {
                money.Property(m => m.Amount)
                    .HasColumnName("ApplicationFees")
                    .HasPrecision(18, 2)
                    .IsRequired();

                money.Ignore(m => m.Currency);
            });

            

            builder.ToTable("ApplicationTypes",a =>
            {
                a.HasCheckConstraint("CHK_ApplicationType_Fees", "ApplicationFees >= 0");
            });
        }
    }
}
