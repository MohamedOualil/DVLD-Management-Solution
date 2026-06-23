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
    public class AuditLogConfiguration : BaseEntityConfiguration<AuditLog>
    {
        public override void Configure(EntityTypeBuilder<AuditLog> builder)
        {
            base.Configure(builder);

            builder.Property(a => a.UserName)
                .HasMaxLength(256) 
                .IsRequired();

            builder.Property(a => a.Action)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(a => a.EntityName)
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(a => a.EntityId)
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(a => a.FailureReason)
                .IsRequired(); 

            builder.Property(a => a.IpAddress)
                .HasMaxLength(45) 
                .IsRequired();

            builder.Property(a => a.CreatedAt)
                .IsRequired();

            builder.Property(a => a.OldValues)
                .IsRequired(false);

            builder.Property(a => a.NewValues)
                .IsRequired(false);

            builder.HasIndex(a => new { a.EntityName, a.EntityId }); 
            builder.HasIndex(a => a.UserId); 
            builder.HasIndex(a => a.CreatedAt);

            builder.ToTable("AuditLogs");
        }
    }
}
