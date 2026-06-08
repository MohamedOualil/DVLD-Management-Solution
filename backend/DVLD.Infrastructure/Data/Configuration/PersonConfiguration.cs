using DVLD.Domain.Entities;
using DVLD.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Infrastructure.Data.Configuration
{
    public class PersonConfiguration : BaseEntityConfiguration<Person>
    {
        public override void Configure(EntityTypeBuilder<Person> builder)
        {
            base.Configure(builder);

            builder.OwnsOne(p => p.FullName, fullName =>
            {
                fullName.Property(s => s.FirstName)
                .HasColumnName("FirstName")
                .IsRequired()
                .HasMaxLength(20);

                fullName.Property(s => s.SecondName)
                    .HasColumnName("SecondName")
                    .HasMaxLength(20);

                fullName.Property(s => s.ThirdName)
                    .HasColumnName("ThirdName")
                    .HasMaxLength(20);

                fullName.Property(s => s.LastName)
                    .HasColumnName("LastName")
                    .IsRequired()
                    .HasMaxLength(20);
            });

            builder.OwnsOne(p => p.NationalNo, nationalNo =>
            {
                nationalNo.Property(v => v.Number)
                .HasColumnName("NationalNo")
                .IsRequired()
                .HasMaxLength(20);

                nationalNo.HasIndex(v => v.Number)
                .IsUnique()
                .HasDatabaseName("UQ_Persons_NationalNo"); 
            });

            builder.Property(s => s.DateOfBirth)
                .HasColumnType("date")
                .IsRequired();

            builder.Property(s => s.Gender)
                .HasColumnType("tinyint")
                .HasConversion<byte>()
                .IsRequired();

            builder.OwnsOne(p => p.Address, address =>
            {
                address.Property(v => v.Street)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("Street");

                address.Property(v => v.State)
                       .IsRequired()
                       .HasMaxLength(100)
                       .HasColumnName("State");

                address.Property(v => v.City)
                       .IsRequired()
                       .HasMaxLength(100)
                       .HasColumnName("City");

                address.Property(v => v.ZipCode)
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnName("ZipCode");
            });

            builder.Property(p => p.NationalityCountryId)
                .IsRequired();

            builder.HasOne(p => p.NationalityCountry)
                .WithMany() 
                .HasForeignKey(p => p.NationalityCountryId)
                .OnDelete(DeleteBehavior.NoAction); 

            builder.OwnsOne(p => p.Phone, phone =>
            {
                phone.Property(v => v.PhoneNumber)
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnName("Phone");
            });

            builder.OwnsOne(p => p.Email, email =>
            {
                email.Property(v => v.Value)
                    .HasMaxLength(150)
                    .HasColumnName("Email");

                email.HasIndex(e => e.Value)
                    .IsUnique()
                    .HasDatabaseName("UQ_Persons_Email")
                    .HasFilter("[Email] IS NOT NULL");

            });

            builder.Property(p => p.ImagePath).HasMaxLength(500);

            builder.Property(p => p.CreateAt)
               .HasDefaultValueSql("SYSUTCDATETIME()")
               .ValueGeneratedOnAdd();

            builder.Property(p => p.UpdateAt)
               .HasDefaultValueSql("SYSUTCDATETIME()")
               .ValueGeneratedOnAddOrUpdate();

            builder.ToTable("Persons", t =>
            {
                t.HasCheckConstraint("CHK_Persons_Gender", "Gender > 0");
            });
        }
    }
}
