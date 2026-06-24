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

            builder.Property(u => u.UserId).IsRequired();

            builder.Property(u => u.RefreshTokenHash).IsRequired()
                    .HasMaxLength(500);

            builder.Property(u => u.ExpiresAt)
                .HasColumnType("DATETIME2")
                .IsRequired();

            builder.Property(u => u.RevokedAt)
                .HasColumnType("DATETIME2");

            builder.Property(u => u.CreatedIp)
                .HasMaxLength(50);

            builder.Property(u => u.DeviceInfo)
                .HasMaxLength(255);

            builder.Property(p => p.CreateAt)
               .HasDefaultValueSql("SYSUTCDATETIME()")
               .ValueGeneratedOnAdd();

            builder.Property(s => s.DeviceId)
                .IsRequired()
                .HasMaxLength(255);


            builder.HasOne(us => us.User)
               .WithMany() 
               .HasForeignKey(us => us.UserId)
               .HasConstraintName("FK_UserSessions_Users")
               .OnDelete(DeleteBehavior.Cascade);


            builder.ToTable("UserSessions");
                
        }
    }
}
