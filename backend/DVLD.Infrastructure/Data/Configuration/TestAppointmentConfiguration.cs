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
    public class TestAppointmentConfiguration : BaseEntityConfiguration<TestAppointment>
    {
        public override void Configure(EntityTypeBuilder<TestAppointment> builder)
        {
            base.Configure(builder);

            builder.HasOne(t => t.TestTypes)
                .WithMany()
                .HasForeignKey(t => t.TestTypeId)
                .HasConstraintName("FK_TestAppointments_TestTypes")
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(t => t.LocalDrivingLicense)
                .WithMany(l => l.TestAppointments)
                .HasForeignKey(t => t.LocalDrivingLicenseApplicationId)
                .HasConstraintName("FK_TestAppointments_LDLA")
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(t => t.CreatedBy)
                .WithMany()
                .HasForeignKey(t => t.CreatedByUserId)
                .HasConstraintName("FK_TestAppointments_Users")
                .OnDelete(DeleteBehavior.NoAction);

            builder.OwnsOne(x => x.PaidFees, money =>
            {
                money.Property(m => m.Amount)
                    .HasColumnName("PaidFees")
                    .HasPrecision(18, 2)
                    .IsRequired();

                money.Ignore(m => m.Currency);
            });


            builder.Property(t => t.AppointmentDate)
                .HasColumnType("DATETIME2")
                .IsRequired();

            builder.Property(t => t.IsLocked)
                .IsRequired()
                .HasDefaultValue(false);

            builder.Property(t => t.CreateAt)
                .HasDefaultValueSql("SYSUTCDATETIME()")
                .ValueGeneratedOnAdd();

            builder.Ignore(t => t.TestTypeEnum);


            builder.ToTable("TestAppointments", t =>
            {
                t.HasCheckConstraint("CK_TestAppointments_PaidFees", "PaidFees >= 0");
                t.HasCheckConstraint("CK_TestAppointments_AppointmentDate", "AppointmentDate > CreateAt");
            });
        }
    }
}
