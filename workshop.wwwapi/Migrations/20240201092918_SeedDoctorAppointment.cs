using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class SeedDoctorAppointment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "appointment_date",
                table: "appointments",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.InsertData(
                table: "doctors",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "Dr. House" },
                    { 2, "Dr. Phil" }
                });

            migrationBuilder.InsertData(
                table: "appointments",
                columns: new[] { "doctor_id", "patient_id", "appointment_date" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 10, 12, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, new DateTime(2024, 10, 12, 16, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_appointments_doctor_id",
                table: "appointments",
                column: "doctor_id");

            migrationBuilder.AddForeignKey(
                name: "FK_appointments_doctors_doctor_id",
                table: "appointments",
                column: "doctor_id",
                principalTable: "doctors",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_appointments_patients_patient_id",
                table: "appointments",
                column: "patient_id",
                principalTable: "patients",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_appointments_doctors_doctor_id",
                table: "appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_appointments_patients_patient_id",
                table: "appointments");

            migrationBuilder.DropIndex(
                name: "IX_appointments_doctor_id",
                table: "appointments");

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctor_id", "patient_id" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctor_id", "patient_id" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.AlterColumn<DateTime>(
                name: "appointment_date",
                table: "appointments",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");
        }
    }
}
