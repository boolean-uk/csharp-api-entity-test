using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class clinic10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PatientId",
                table: "perscription",
                newName: "patientid");

            migrationBuilder.RenameColumn(
                name: "DoctorId",
                table: "perscription",
                newName: "doctorid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "patientid",
                table: "perscription",
                newName: "PatientId");

            migrationBuilder.RenameColumn(
                name: "doctorid",
                table: "perscription",
                newName: "DoctorId");
        }
    }
}
