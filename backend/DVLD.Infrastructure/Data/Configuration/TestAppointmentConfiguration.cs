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
    public class TestAppointmentConfiguration : BaseEntityConfiguration<TestAppointment,int>
    {
        public override void Configure(EntityTypeBuilder<TestAppointment> builder)
        {
            base.Configure(builder);

            
            builder.HasOne(ta => ta.LocalDrivingLicense)
                .WithMany() 
                .HasForeignKey(ta => ta.LocalDrivingLicenseApplicationId)
                .OnDelete(DeleteBehavior.Restrict);


            builder.HasOne(ta => ta.TestTypes)
                .WithMany()
                .HasForeignKey(ta => (int)ta.TestTypeId)
                .OnDelete(DeleteBehavior.Restrict);

           
            builder.Property(ta => ta.AppointmentDate).IsRequired();
            builder.Property(ta => ta.IsLocked).IsRequired().HasDefaultValue(false);

            
            builder.OwnsOne(ta => ta.PaidFees, money =>
            {
                money.Property(m => m.Amount).HasColumnName("PaidFees").HasPrecision(18, 2);
                money.Property(m => m.Currency).HasMaxLength(3).HasDefaultValue("USD");
            });

            builder.HasOne(ta => ta.CreatedBy)
                .WithMany()
                .HasForeignKey(ta => ta.CreatedByUserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("TestAppointments");
        }
    }
}
