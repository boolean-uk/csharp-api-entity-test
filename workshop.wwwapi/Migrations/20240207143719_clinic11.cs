using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class clinic11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "MedicinPerscription",
                newName: "quantity");

            migrationBuilder.RenameColumn(
                name: "PerscriptionId",
                table: "MedicinPerscription",
                newName: "perscriptionid");

            migrationBuilder.RenameColumn(
                name: "Note",
                table: "MedicinPerscription",
                newName: "note");

            migrationBuilder.RenameColumn(
                name: "MedicinId",
                table: "MedicinPerscription",
                newName: "medicinid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "quantity",
                table: "MedicinPerscription",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "perscriptionid",
                table: "MedicinPerscription",
                newName: "PerscriptionId");

            migrationBuilder.RenameColumn(
                name: "note",
                table: "MedicinPerscription",
                newName: "Note");

            migrationBuilder.RenameColumn(
                name: "medicinid",
                table: "MedicinPerscription",
                newName: "MedicinId");
        }
    }
}
