using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class clinic7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Perscription",
                table: "Perscription");

            migrationBuilder.RenameTable(
                name: "Perscription",
                newName: "perscription");

            migrationBuilder.AddColumn<int>(
                name: "PatientId",
                table: "perscription",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_perscription",
                table: "perscription",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_perscription",
                table: "perscription");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "perscription");

            migrationBuilder.RenameTable(
                name: "perscription",
                newName: "Perscription");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Perscription",
                table: "Perscription",
                column: "Id");
        }
    }
}
