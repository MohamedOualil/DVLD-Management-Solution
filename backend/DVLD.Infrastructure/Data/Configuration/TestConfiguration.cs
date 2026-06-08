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
    public class TestConfiguration : BaseEntityConfiguration<Test>
    {
        public override void Configure(EntityTypeBuilder<Test> builder)
        {
            base.Configure(builder);

            builder.HasIndex(t => t.TestAppointmentId)
                .IsUnique()
                .HasDatabaseName("UQ_Tests_TestAppointmentId");

            builder.HasOne(t => t.TestAppointment)
                .WithOne(ta => ta.Test) 
                .HasForeignKey<Test>(t => t.TestAppointmentId)
                .HasConstraintName("FK_Tests_TestAppointments")
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(t => t.CreatedBy)
                 .WithMany()
                 .HasForeignKey(t => t.CreatedByUserId)
                 .HasConstraintName("FK_Tests_Users")
                 .OnDelete(DeleteBehavior.NoAction);

            
            builder.Property(t => t.TestResult)
                .HasColumnType("TINYINT")
                .IsRequired()
                .HasConversion<byte>();


            builder.Property(t => t.Notes)
                .HasColumnType("NVARCHAR(MAX)")
                .HasMaxLength(500) 
                .IsRequired(false);


            builder.ToTable("Tests", t =>
            {
                t.HasCheckConstraint("CK_Tests_TestResult", "TestResult IN (0,1)");
            });
        }
    }
}
