using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class AddPredMed4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "AppointmentBooking",
                table: "prescript",
                type: "Date",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AppointmentDoctorId",
                table: "prescript",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AppointmentPatientId",
                table: "prescript",
                type: "integer",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "prescript",
                keyColumns: new[] { "MedicineId", "PrescriptionId" },
                keyValues: new object[] { 1, 1 },
                columns: new[] { "AppointmentBooking", "AppointmentDoctorId", "AppointmentPatientId" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "prescript",
                keyColumns: new[] { "MedicineId", "PrescriptionId" },
                keyValues: new object[] { 2, 2 },
                columns: new[] { "AppointmentBooking", "AppointmentDoctorId", "AppointmentPatientId" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "prescript",
                keyColumns: new[] { "MedicineId", "PrescriptionId" },
                keyValues: new object[] { 3, 3 },
                columns: new[] { "AppointmentBooking", "AppointmentDoctorId", "AppointmentPatientId" },
                values: new object[] { null, null, null });

            migrationBuilder.CreateIndex(
                name: "IX_prescript_AppointmentDoctorId_AppointmentPatientId_Appointm~",
                table: "prescript",
                columns: new[] { "AppointmentDoctorId", "AppointmentPatientId", "AppointmentBooking" });

            migrationBuilder.AddForeignKey(
                name: "FK_prescript_appointment_AppointmentDoctorId_AppointmentPatien~",
                table: "prescript",
                columns: new[] { "AppointmentDoctorId", "AppointmentPatientId", "AppointmentBooking" },
                principalTable: "appointment",
                principalColumns: new[] { "DoctorId", "PatientId", "date" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_prescript_appointment_AppointmentDoctorId_AppointmentPatien~",
                table: "prescript");

            migrationBuilder.DropIndex(
                name: "IX_prescript_AppointmentDoctorId_AppointmentPatientId_Appointm~",
                table: "prescript");

            migrationBuilder.DropColumn(
                name: "AppointmentBooking",
                table: "prescript");

            migrationBuilder.DropColumn(
                name: "AppointmentDoctorId",
                table: "prescript");

            migrationBuilder.DropColumn(
                name: "AppointmentPatientId",
                table: "prescript");
        }
    }
}
