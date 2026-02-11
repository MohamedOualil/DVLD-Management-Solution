using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DVLD.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixCountryID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Person_Counties_Address_CountryID",
                table: "Person");

            migrationBuilder.DropForeignKey(
                name: "FK_Person_Counties_NationalNo_CountryID",
                table: "Person");

            migrationBuilder.DropIndex(
                name: "IX_Person_Email_Value",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "Address_CountryID1",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "NationalNo_CountryID1",
                table: "Person");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Person",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "Email_Value",
                table: "Person",
                newName: "Email");

            migrationBuilder.AlterColumn<int>(
                name: "NationalNo_CountryID",
                table: "Person",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ImagePath",
                table: "Person",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Address_CountryID",
                table: "Person",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    IsDeactivated = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Person_Email",
                table: "Person",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Users_PersonId",
                table: "Users",
                column: "PersonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName",
                table: "Users",
                column: "UserName",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Counties_Address_CountryID",
                table: "Person",
                column: "Address_CountryID",
                principalTable: "Counties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Counties_NationalNo_CountryID",
                table: "Person",
                column: "NationalNo_CountryID",
                principalTable: "Counties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
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
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Person_Email",
                table: "Person");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Person",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Person",
                newName: "Email_Value");

            migrationBuilder.AlterColumn<int>(
                name: "NationalNo_CountryID",
                table: "Person",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "ImagePath",
                table: "Person",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Address_CountryID",
                table: "Person",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Address_CountryID1",
                table: "Person",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NationalNo_CountryID1",
                table: "Person",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Person_Email_Value",
                table: "Person",
                column: "Email_Value",
                unique: true,
                filter: "[Email_Value] IS NOT NULL");

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
    }
}
