using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DVLD.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Test_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TestAppointmentId = table.Column<int>(type: "int", nullable: false),
                    TestResult = table.Column<bool>(type: "bit", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: false),
                    IsDeactivated = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tests_TestAppointments_TestAppointmentId",
                        column: x => x.TestAppointmentId,
                        principalTable: "TestAppointments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tests_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tests_CreatedByUserId",
                table: "Tests",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tests_TestAppointmentId",
                table: "Tests",
                column: "TestAppointmentId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tests");
        }
    }
}
