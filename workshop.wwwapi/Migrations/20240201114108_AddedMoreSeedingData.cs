using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class AddedMoreSeedingData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumns: new[] { "doctor_id", "patient_id" },
                keyValues: new object[] { 1, 1 },
                column: "booking",
                value: new DateTime(2024, 2, 1, 11, 41, 8, 258, DateTimeKind.Utc).AddTicks(8145));

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumns: new[] { "doctor_id", "patient_id" },
                keyValues: new object[] { 1, 2 },
                column: "booking",
                value: new DateTime(2024, 2, 2, 11, 41, 8, 258, DateTimeKind.Utc).AddTicks(8274));

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumns: new[] { "doctor_id", "patient_id" },
                keyValues: new object[] { 3, 3 },
                column: "booking",
                value: new DateTime(2024, 2, 2, 11, 41, 8, 258, DateTimeKind.Utc).AddTicks(8274));

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumns: new[] { "doctor_id", "patient_id" },
                keyValues: new object[] { 2, 4 },
                column: "booking",
                value: new DateTime(2024, 2, 2, 11, 41, 8, 258, DateTimeKind.Utc).AddTicks(8274));

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumns: new[] { "doctor_id", "patient_id" },
                keyValues: new object[] { 3, 4 },
                column: "booking",
                value: new DateTime(2024, 2, 1, 11, 41, 8, 258, DateTimeKind.Utc).AddTicks(8145));

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumns: new[] { "doctor_id", "patient_id" },
                keyValues: new object[] { 2, 5 },
                column: "booking",
                value: new DateTime(2024, 2, 1, 11, 41, 8, 258, DateTimeKind.Utc).AddTicks(8145));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                keyValues: new object[] { 1, 2 },
                column: "booking",
                value: new DateTime(2024, 2, 1, 15, 40, 6, 405, DateTimeKind.Utc).AddTicks(3347));

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumns: new[] { "doctor_id", "patient_id" },
                keyValues: new object[] { 3, 3 },
                column: "booking",
                value: new DateTime(2024, 2, 1, 15, 40, 6, 405, DateTimeKind.Utc).AddTicks(3347));

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumns: new[] { "doctor_id", "patient_id" },
                keyValues: new object[] { 2, 4 },
                column: "booking",
                value: new DateTime(2024, 2, 1, 15, 40, 6, 405, DateTimeKind.Utc).AddTicks(3347));

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumns: new[] { "doctor_id", "patient_id" },
                keyValues: new object[] { 3, 4 },
                column: "booking",
                value: new DateTime(2024, 1, 31, 15, 40, 6, 405, DateTimeKind.Utc).AddTicks(3253));

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumns: new[] { "doctor_id", "patient_id" },
                keyValues: new object[] { 2, 5 },
                column: "booking",
                value: new DateTime(2024, 1, 31, 15, 40, 6, 405, DateTimeKind.Utc).AddTicks(3253));
        }
    }
}
