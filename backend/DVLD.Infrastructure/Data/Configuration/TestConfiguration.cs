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
    public class TestConfiguration : BaseEntityConfiguration<Test, int>
    {
        public override void Configure(EntityTypeBuilder<Test> builder)
        {
            base.Configure(builder);

            builder.HasOne(t => t.TestAppointment)
                .WithOne() 
                .HasForeignKey<Test>(t => t.TestAppointmentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(t => t.TestResult)
                .IsRequired();

            builder.Property(t => t.Notes)
                .HasMaxLength(500);

            builder.HasOne(t => t.CreatedBy)
                .WithMany()
                .HasForeignKey(t => t.CreatedByUserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("Tests");
        }
    }
}
