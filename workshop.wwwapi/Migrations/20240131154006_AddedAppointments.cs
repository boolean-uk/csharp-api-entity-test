using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class AddedAppointments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumns: new[] { "doctor_id", "patient_id" },
                keyValues: new object[] { 1, 1 },
                column: "booking",
                value: new DateTime(2024, 1, 31, 15, 40, 6, 405, DateTimeKind.Utc).AddTicks(3253));

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumns: new[] { "doctor_id", "patient_id" },
                keyValues: new object[] { 3, 4 },
                column: "booking",
                value: new DateTime(2024, 1, 31, 15, 40, 6, 405, DateTimeKind.Utc).AddTicks(3253));

            migrationBuilder.InsertData(
                table: "appointments",
                columns: new[] { "doctor_id", "patient_id", "booking" },
                values: new object[,]
                {
                    { 1, 2, new DateTime(2024, 2, 1, 15, 40, 6, 405, DateTimeKind.Utc).AddTicks(3347) },
                    { 3, 3, new DateTime(2024, 2, 1, 15, 40, 6, 405, DateTimeKind.Utc).AddTicks(3347) },
                    { 2, 4, new DateTime(2024, 2, 1, 15, 40, 6, 405, DateTimeKind.Utc).AddTicks(3347) },
                    { 2, 5, new DateTime(2024, 1, 31, 15, 40, 6, 405, DateTimeKind.Utc).AddTicks(3253) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctor_id", "patient_id" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctor_id", "patient_id" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctor_id", "patient_id" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctor_id", "patient_id" },
                keyValues: new object[] { 2, 5 });

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumns: new[] { "doctor_id", "patient_id" },
                keyValues: new object[] { 1, 1 },
                column: "booking",
                value: new DateTime(2024, 1, 31, 15, 13, 5, 773, DateTimeKind.Utc).AddTicks(7048));

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumns: new[] { "doctor_id", "patient_id" },
                keyValues: new object[] { 3, 4 },
                column: "booking",
                value: new DateTime(2024, 1, 31, 15, 13, 5, 773, DateTimeKind.Utc).AddTicks(7048));
        }
    }
}
