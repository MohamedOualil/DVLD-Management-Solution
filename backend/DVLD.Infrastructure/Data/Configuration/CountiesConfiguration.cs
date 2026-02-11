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
    public class CountiesConfiguration : BaseEntityConfiguration<Counties,int>
    {
        public override void Configure(EntityTypeBuilder<Counties> builder)
        {
            base.Configure(builder);

            builder.Property(p =>p.CountryName).IsRequired()
                .HasMaxLength(50);
            builder.Property(p => p.CountryCode).IsRequired()
                .HasMaxLength(5);
        }
    }
}
