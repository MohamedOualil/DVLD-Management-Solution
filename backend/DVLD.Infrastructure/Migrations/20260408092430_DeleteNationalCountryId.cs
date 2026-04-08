using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DVLD.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DeleteNationalCountryId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Person_Counties_NationalNo_CountryID",
                table: "Person");

            migrationBuilder.DropIndex(
                name: "IX_Person_NationalNo_CountryID",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "NationalNo_CountryID",
                table: "Person");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NationalNo_CountryID",
                table: "Person",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Person_NationalNo_CountryID",
                table: "Person",
                column: "NationalNo_CountryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Counties_NationalNo_CountryID",
                table: "Person",
                column: "NationalNo_CountryID",
                principalTable: "Counties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
