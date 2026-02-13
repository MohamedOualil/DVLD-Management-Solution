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
    public class ApplicationTypesConfiguration : BaseEntityConfiguration<ApplicationTypes, ApplicationType>
    {
        public override void Configure(EntityTypeBuilder<ApplicationTypes> builder)
        {
        
            builder.HasKey(x => x.Id);


            builder.Property(x => x.Id)
                .HasConversion<int>()
                .ValueGeneratedNever(); 

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

            base.Configure(builder);

            builder.ToTable("ApplicationTypes");
        }
    }
}
