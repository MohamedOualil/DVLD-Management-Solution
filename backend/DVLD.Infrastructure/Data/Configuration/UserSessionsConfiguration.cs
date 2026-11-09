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
    public class UserSessionsConfiguration : BaseEntityConfiguration<UserSession>
    {
        public override void Configure(EntityTypeBuilder<UserSession> builder)
        {
            base.Configure(builder);

            builder.ToTable("UserSessions");

            builder.Property(s => s.UserId).IsRequired();

            builder.Property(s => s.RefreshTokenHash)
                .IsRequired()
                .HasMaxLength(128);


            builder.Property(s => s.CreatedAt)
                .HasColumnType("DATETIME2")
                .IsRequired();

            builder.Property(s => s.ExpiresAt)
                .HasColumnType("DATETIME2")
                .IsRequired();

            builder.Property(s => s.RevokedAt)
                .HasColumnType("DATETIME2");

            builder.HasIndex(s => s.UserId).IsUnique();
            builder.HasIndex(s => s.RefreshTokenHash).IsUnique();

            builder.Ignore(s => s.IsActive);
            builder.Ignore(s => s.IsExpired);
            builder.Ignore(s => s.IsRevoked);

            builder.HasOne(us => us.User)
               .WithMany() 
               .HasForeignKey(us => us.UserId)
               .HasConstraintName("FK_UserSessions_Users")
               .OnDelete(DeleteBehavior.Cascade);


                
        }
    }
}
