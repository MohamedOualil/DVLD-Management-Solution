using DVLD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DVLD.Infrastructure.Data.Configuration
{
    public class PersonConfiguration : BaseEntityConfiguration<Person,int>
    {
        public override void Configure(EntityTypeBuilder<Person> builder)
        {
            base.Configure(builder);


            builder.Property(s => s.FirstName).IsRequired()
                .HasMaxLength(20);
            builder.Property(s => s.SecondName)
                .HasMaxLength(20);
            builder.Property(s => s.ThirdName)
                .HasMaxLength(20);
            builder.Property(s => s.LastName).IsRequired()
                .HasMaxLength(20);

            builder.OwnsOne(p => p.NationalNo, nationalNo =>
            {
                nationalNo.Property(v => v.Number).IsRequired().HasMaxLength(20);
                nationalNo.Property(v => v.CountryID).IsRequired();

                builder.HasOne<Counties>().WithMany()
                .HasForeignKey("NationalNo_CountryID");

                nationalNo.HasIndex(v => v.Number).IsUnique();
            });

            builder.Property(s => s.DateOfBirth).IsRequired();
            builder.Property(s => s.Gender).IsRequired().HasConversion<short>();

            builder.OwnsOne(p => p.Address, a =>
            {
                a.Property(v => v.Street).IsRequired()
                                    .HasMaxLength(100)
                                    .HasColumnName("Street");
                a.Property(v => v.State).IsRequired()
                                    .HasMaxLength(50)
                                    .HasColumnName("State");
                a.Property(v => v.City).IsRequired().HasMaxLength(50)
                                        .HasColumnName("City");
                a.Property(v => v.ZipCode).IsRequired().HasMaxLength(10)
                                        .HasColumnName("ZipCode");
                a.Property(v => v.CountryID).IsRequired();

                builder.HasOne<Counties>().WithMany()
                        .HasForeignKey("Address_CountryID");
            });

            builder.OwnsOne(p => p.Phone, phone =>
            {
                phone.Property(v => v.PhoneNumber).IsRequired()
                        .HasMaxLength(20)
                        .HasColumnName("PhoneNumber");
            });

            builder.OwnsOne(p => p.Email, email =>
            {
                email.Property(v => v.Value).HasMaxLength(100);
                email.HasIndex(v => v.Value).IsUnique();
            });

            builder.ToTable("Person");
        }
    }
}
