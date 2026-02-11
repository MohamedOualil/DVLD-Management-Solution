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
    public class UserConfiguration : BaseEntityConfiguration<User, int>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);
            builder.ToTable("Users");
            builder.Property(p=>p.UserName).IsRequired()
                .HasMaxLength(20);
            builder.HasIndex(p => p.UserName).IsUnique();

            builder.Property(p => p.PasswordHash).IsRequired()
                    .HasMaxLength(255);

            builder.HasOne(u => u.Person)
                .WithOne()
                .HasForeignKey<User>(p => p.PersonId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
