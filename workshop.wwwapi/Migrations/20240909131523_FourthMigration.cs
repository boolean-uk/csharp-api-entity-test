using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class FourthMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "lastname",
                table: "patients",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "firstname",
                table: "patients",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "patients",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Doctors",
                newName: "FirstName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "patients",
                newName: "lastname");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "patients",
                newName: "firstname");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "patients",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Doctors",
                newName: "FullName");
        }
    }
}
