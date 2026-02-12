using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DVLD.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class LicenseClasses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LicenseClasses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ClassDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    MinimumAllowedAge = table.Column<byte>(type: "tinyint", nullable: false),
                    DefaultValidityLength = table.Column<byte>(type: "tinyint", nullable: false),
                    ClassFees = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    ClassFees_Currency = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false, defaultValue: "USD"),
                    IsDeactivated = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LicenseClasses", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LicenseClasses");
        }
    }
}
