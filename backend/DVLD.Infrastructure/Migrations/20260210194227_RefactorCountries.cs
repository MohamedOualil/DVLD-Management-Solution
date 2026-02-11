using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DVLD.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RefactorCountries : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address_Country",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "NationalNo_CountryCode",
                table: "Person");

            migrationBuilder.RenameColumn(
                name: "Phone_PhoneNumber",
                table: "Person",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "Address_ZipCode",
                table: "Person",
                newName: "ZipCode");

            migrationBuilder.RenameColumn(
                name: "Address_Street",
                table: "Person",
                newName: "Street");

            migrationBuilder.RenameColumn(
                name: "Address_State",
                table: "Person",
                newName: "State");

            migrationBuilder.RenameColumn(
                name: "Address_City",
                table: "Person",
                newName: "City");

            migrationBuilder.AddColumn<int>(
                name: "Address_CountryID",
                table: "Person",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Address_CountryID1",
                table: "Person",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NationalNo_CountryID",
                table: "Person",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NationalNo_CountryID1",
                table: "Person",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Counties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeactivated = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Counties", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Person_Address_CountryID",
                table: "Person",
                column: "Address_CountryID");

            migrationBuilder.CreateIndex(
                name: "IX_Person_NationalNo_CountryID",
                table: "Person",
                column: "NationalNo_CountryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Counties_Address_CountryID",
                table: "Person",
                column: "Address_CountryID",
                principalTable: "Counties",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Counties_NationalNo_CountryID",
                table: "Person",
                column: "NationalNo_CountryID",
                principalTable: "Counties",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Person_Counties_Address_CountryID",
                table: "Person");

            migrationBuilder.DropForeignKey(
                name: "FK_Person_Counties_NationalNo_CountryID",
                table: "Person");

            migrationBuilder.DropTable(
                name: "Counties");

            migrationBuilder.DropIndex(
                name: "IX_Person_Address_CountryID",
                table: "Person");

            migrationBuilder.DropIndex(
                name: "IX_Person_NationalNo_CountryID",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "Address_CountryID",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "Address_CountryID1",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "NationalNo_CountryID",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "NationalNo_CountryID1",
                table: "Person");

            migrationBuilder.RenameColumn(
                name: "ZipCode",
                table: "Person",
                newName: "Address_ZipCode");

            migrationBuilder.RenameColumn(
                name: "Street",
                table: "Person",
                newName: "Address_Street");

            migrationBuilder.RenameColumn(
                name: "State",
                table: "Person",
                newName: "Address_State");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Person",
                newName: "Phone_PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "Person",
                newName: "Address_City");

            migrationBuilder.AddColumn<string>(
                name: "Address_Country",
                table: "Person",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NationalNo_CountryCode",
                table: "Person",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: false,
                defaultValue: "");
        }
    }
}
