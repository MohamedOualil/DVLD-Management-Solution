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
    public class ApplicationTypesConfiguration : BaseEntityConfiguration<ApplicationTypes, int>
    {
        public override void Configure(EntityTypeBuilder<ApplicationTypes> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.ApplicationName)
                .IsRequired()
                .HasMaxLength(150);

            builder.OwnsOne(x => x.ApplicationFees, money =>
            {
                money.Property(m => m.Amount)
                    .HasColumnName("ApplicationFees")
                    .HasPrecision(18, 2)
                    .IsRequired();

                money.Property(m => m.Currency)
                    .HasMaxLength(3)
                    .IsRequired()
                    .HasDefaultValue("USD");
            });
        }
    }
}
