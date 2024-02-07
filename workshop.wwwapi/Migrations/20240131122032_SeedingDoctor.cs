using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDoctor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "doctor",
                columns: new[] { "id", "fullname" },
                values: new object[,]
                {
                    { 1, "Dr.Johanna" },
                    { 2, "Dr.Jon" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_appointment_doctor_id",
                table: "appointment",
                column: "doctor_id");

            migrationBuilder.AddForeignKey(
                name: "FK_appointment_doctor_doctor_id",
                table: "appointment",
                column: "doctor_id",
                principalTable: "doctor",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_appointment_patient_patient_id",
                table: "appointment",
                column: "patient_id",
                principalTable: "patient",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_appointment_doctor_doctor_id",
                table: "appointment");

            migrationBuilder.DropForeignKey(
                name: "FK_appointment_patient_patient_id",
                table: "appointment");

            migrationBuilder.DropIndex(
                name: "IX_appointment_doctor_id",
                table: "appointment");

            migrationBuilder.DeleteData(
                table: "doctor",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "doctor",
                keyColumn: "id",
                keyValue: 2);
        }
    }
}
