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
    public class UserConfiguration : BaseEntityConfiguration<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.UserName).IsRequired()
                .HasMaxLength(20);

            builder.HasIndex(p => p.UserName)
                .HasDatabaseName("UQ_Users_UserName")
                .IsUnique();

            builder.Property(p => p.Role)
                .HasColumnType("tinyint")
                .IsRequired();

            builder.Property(p => p.PasswordHash).IsRequired()
                    .HasMaxLength(255);

            builder.Property(p => p.IsActive).IsRequired()
                .HasDefaultValue(true);

            builder.HasIndex(p => p.PersonId).IsUnique()
                .HasDatabaseName("UQ_Users_PersonId");

            builder.Property(p => p.CreateAt)
               .HasDefaultValueSql("SYSUTCDATETIME()")
               .ValueGeneratedOnAdd();

            builder.Property(p => p.UpdateAt)
               .HasDefaultValueSql("SYSUTCDATETIME()")
               .ValueGeneratedOnAddOrUpdate();

            builder.HasOne(u => u.Person)
                .WithOne()
                .HasForeignKey<User>(p => p.PersonId)
                .HasConstraintName("FK_Users_Persons")
                .OnDelete(DeleteBehavior.NoAction);

            builder.ToTable("Users");
        }
    }
}
