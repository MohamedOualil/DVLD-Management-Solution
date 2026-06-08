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
    public class TestTypesConfiguration : BaseEntityConfiguration<TestType>
    {
        public override void Configure(EntityTypeBuilder<TestType> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.TestTypeTitle)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.TestTypeDescrption)
                .IsRequired()
                .HasMaxLength(500);

            
            builder.OwnsOne(x => x.TestFees, money =>
            {
                money.Property(m => m.Amount)
                    .HasColumnName("TestFees")
                    .HasPrecision(18, 2)
                    .IsRequired();

                money.Ignore(c => c.Currency);
            });

            builder.ToTable("TestTypes", t =>
            {
                t.HasCheckConstraint("CHK_TestTypes_TestFees", "TestFees >= 0");
            });
        }
    }
}
