using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class seedingAppointment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "appointment",
                columns: new[] { "doctor_id", "patient_id", "booking" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 1, 31, 12, 26, 16, 98, DateTimeKind.Utc).AddTicks(4269) },
                    { 2, 1, new DateTime(2024, 1, 31, 12, 26, 16, 98, DateTimeKind.Utc).AddTicks(4272) },
                    { 1, 2, new DateTime(2024, 1, 31, 12, 26, 16, 98, DateTimeKind.Utc).AddTicks(4271) },
                    { 2, 2, new DateTime(2024, 1, 31, 12, 26, 16, 98, DateTimeKind.Utc).AddTicks(4272) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "appointment",
                keyColumns: new[] { "doctor_id", "patient_id" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "appointment",
                keyColumns: new[] { "doctor_id", "patient_id" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "appointment",
                keyColumns: new[] { "doctor_id", "patient_id" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "appointment",
                keyColumns: new[] { "doctor_id", "patient_id" },
                keyValues: new object[] { 2, 2 });
        }
    }
}
