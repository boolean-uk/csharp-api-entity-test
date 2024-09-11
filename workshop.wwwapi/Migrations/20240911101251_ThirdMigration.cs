using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class ThirdMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Doctor",
                columns: new[] { "Id", "full_name" },
                values: new object[,]
                {
                    { 1, "Doctor Coleman" },
                    { 2, "Doctor Shultz" }
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "DoctorId", "PatientId", "Booking" },
                values: new object[,]
                {
                    { 1, 2, new DateTime(2024, 9, 11, 10, 12, 50, 31, DateTimeKind.Utc).AddTicks(3839) },
                    { 2, 2, new DateTime(2024, 9, 11, 10, 12, 50, 31, DateTimeKind.Utc).AddTicks(3839) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumns: new[] { "DoctorId", "PatientId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumns: new[] { "DoctorId", "PatientId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "Doctor",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Doctor",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
