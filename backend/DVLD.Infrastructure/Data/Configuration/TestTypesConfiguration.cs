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
    public class TestTypesConfiguration : BaseEntityConfiguration<TestTypes,TestType>
    {
        public override void Configure(EntityTypeBuilder<TestTypes> builder)
        {
            builder.HasKey(x => x.Id);

           
            builder.Property(x => x.Id)
                .HasConversion<int>();

            builder.Property(x => x.TestName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.TestDescription)
                .IsRequired()
                .HasMaxLength(500);

            
            builder.OwnsOne(x => x.TestFees, money =>
            {
                money.Property(m => m.Amount)
                    .HasColumnName("TestFees")
                    .HasPrecision(18, 2)
                    .IsRequired();

                money.Property(m => m.Currency)
                    .HasMaxLength(3)
                    .IsRequired()
                    .HasDefaultValue("USD");
            });

            builder.ToTable("TestTypes");
        }
    }
}
