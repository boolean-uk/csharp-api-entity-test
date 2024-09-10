using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class SixthMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_appointments_doctors_DoctorId",
                table: "appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_appointments_patients_PatientId",
                table: "appointments");

            migrationBuilder.RenameColumn(
                name: "PatientId",
                table: "appointments",
                newName: "patientId");

            migrationBuilder.RenameColumn(
                name: "DoctorId",
                table: "appointments",
                newName: "doctorId");

            migrationBuilder.RenameIndex(
                name: "IX_appointments_PatientId",
                table: "appointments",
                newName: "IX_appointments_patientId");

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId" },
                keyValues: new object[] { 1, 1 },
                column: "booking",
                value: new DateTime(2024, 9, 9, 15, 19, 12, 235, DateTimeKind.Utc).AddTicks(3321));

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumns: new[] { "doctorId", "patientId" },
                keyValues: new object[] { 2, 2 },
                column: "booking",
                value: new DateTime(2024, 9, 9, 15, 19, 12, 235, DateTimeKind.Utc).AddTicks(3327));

            migrationBuilder.AddForeignKey(
                name: "FK_appointments_doctors_doctorId",
                table: "appointments",
                column: "doctorId",
                principalTable: "doctors",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_appointments_patients_patientId",
                table: "appointments",
                column: "patientId",
                principalTable: "patients",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_appointments_doctors_doctorId",
                table: "appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_appointments_patients_patientId",
                table: "appointments");

            migrationBuilder.RenameColumn(
                name: "patientId",
                table: "appointments",
                newName: "PatientId");

            migrationBuilder.RenameColumn(
                name: "doctorId",
                table: "appointments",
                newName: "DoctorId");

            migrationBuilder.RenameIndex(
                name: "IX_appointments_patientId",
                table: "appointments",
                newName: "IX_appointments_PatientId");

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumns: new[] { "DoctorId", "PatientId" },
                keyValues: new object[] { 1, 1 },
                column: "booking",
                value: new DateTime(2024, 9, 9, 14, 0, 25, 95, DateTimeKind.Utc).AddTicks(5921));

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumns: new[] { "DoctorId", "PatientId" },
                keyValues: new object[] { 2, 2 },
                column: "booking",
                value: new DateTime(2024, 9, 9, 14, 0, 25, 95, DateTimeKind.Utc).AddTicks(5925));

            migrationBuilder.AddForeignKey(
                name: "FK_appointments_doctors_DoctorId",
                table: "appointments",
                column: "DoctorId",
                principalTable: "doctors",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_appointments_patients_PatientId",
                table: "appointments",
                column: "PatientId",
                principalTable: "patients",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
