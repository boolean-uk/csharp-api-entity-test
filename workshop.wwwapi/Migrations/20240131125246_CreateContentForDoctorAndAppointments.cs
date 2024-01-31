using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class CreateContentForDoctorAndAppointments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "doctors",
                columns: new[] { "id", "fullnames" },
                values: new object[,]
                {
                    { 1, "Mr. Dentist" },
                    { 2, "Mrs. Cardiologist" }
                });

            migrationBuilder.InsertData(
                table: "appointments",
                columns: new[] { "doctor_id", "patient_id", "booking" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 1, 31, 14, 52, 45, 950, DateTimeKind.Local).ToUniversalTime().AddTicks(633) },
                    { 1, 2, new DateTime(2024, 1, 31, 14, 52, 45, 950, DateTimeKind.Local).ToUniversalTime().AddTicks(731) },
                    { 2, 2, new DateTime(2024, 1, 31, 14, 52, 45, 950, DateTimeKind.Local).ToUniversalTime().AddTicks(692) },
                    { 2, 3, new DateTime(2024, 1, 31, 14, 52, 45, 950, DateTimeKind.Local).ToUniversalTime().AddTicks(727) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctor_id", "patient_id" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctor_id", "patient_id" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctor_id", "patient_id" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctor_id", "patient_id" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 2);
        }
    }
}
