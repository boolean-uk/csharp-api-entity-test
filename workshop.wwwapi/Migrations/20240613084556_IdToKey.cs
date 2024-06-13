using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class IdToKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumns: new[] { "doctor_id", "patient_id" },
                keyValues: new object[] { 1, 1 },
                columns: new[] { "bookings", "id" },
                values: new object[] { new DateTime(2024, 6, 13, 8, 45, 56, 434, DateTimeKind.Utc).AddTicks(6199), 1 });

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumns: new[] { "doctor_id", "patient_id" },
                keyValues: new object[] { 1, 4 },
                columns: new[] { "bookings", "id" },
                values: new object[] { new DateTime(2024, 6, 13, 8, 45, 56, 434, DateTimeKind.Utc).AddTicks(6208), 5 });

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumns: new[] { "doctor_id", "patient_id" },
                keyValues: new object[] { 2, 2 },
                columns: new[] { "bookings", "id" },
                values: new object[] { new DateTime(2024, 6, 13, 8, 45, 56, 434, DateTimeKind.Utc).AddTicks(6204), 2 });

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumns: new[] { "doctor_id", "patient_id" },
                keyValues: new object[] { 2, 3 },
                columns: new[] { "bookings", "id" },
                values: new object[] { new DateTime(2024, 6, 13, 8, 45, 56, 434, DateTimeKind.Utc).AddTicks(6209), 6 });

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumns: new[] { "doctor_id", "patient_id" },
                keyValues: new object[] { 3, 2 },
                columns: new[] { "bookings", "id" },
                values: new object[] { new DateTime(2024, 6, 13, 8, 45, 56, 434, DateTimeKind.Utc).AddTicks(6211), 7 });

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumns: new[] { "doctor_id", "patient_id" },
                keyValues: new object[] { 3, 3 },
                columns: new[] { "bookings", "id" },
                values: new object[] { new DateTime(2024, 6, 13, 8, 45, 56, 434, DateTimeKind.Utc).AddTicks(6206), 3 });

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumns: new[] { "doctor_id", "patient_id" },
                keyValues: new object[] { 4, 1 },
                columns: new[] { "bookings", "id" },
                values: new object[] { new DateTime(2024, 6, 13, 8, 45, 56, 434, DateTimeKind.Utc).AddTicks(6215), 8 });

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumns: new[] { "doctor_id", "patient_id" },
                keyValues: new object[] { 4, 4 },
                columns: new[] { "bookings", "id" },
                values: new object[] { new DateTime(2024, 6, 13, 8, 45, 56, 434, DateTimeKind.Utc).AddTicks(6207), 4 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumns: new[] { "doctor_id", "patient_id" },
                keyValues: new object[] { 1, 1 },
                columns: new[] { "bookings", "id" },
                values: new object[] { new DateTime(2024, 6, 13, 8, 39, 11, 588, DateTimeKind.Utc).AddTicks(1504), 0 });

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumns: new[] { "doctor_id", "patient_id" },
                keyValues: new object[] { 1, 4 },
                columns: new[] { "bookings", "id" },
                values: new object[] { new DateTime(2024, 6, 13, 8, 39, 11, 588, DateTimeKind.Utc).AddTicks(1511), 0 });

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumns: new[] { "doctor_id", "patient_id" },
                keyValues: new object[] { 2, 2 },
                columns: new[] { "bookings", "id" },
                values: new object[] { new DateTime(2024, 6, 13, 8, 39, 11, 588, DateTimeKind.Utc).AddTicks(1508), 0 });

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumns: new[] { "doctor_id", "patient_id" },
                keyValues: new object[] { 2, 3 },
                columns: new[] { "bookings", "id" },
                values: new object[] { new DateTime(2024, 6, 13, 8, 39, 11, 588, DateTimeKind.Utc).AddTicks(1512), 0 });

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumns: new[] { "doctor_id", "patient_id" },
                keyValues: new object[] { 3, 2 },
                columns: new[] { "bookings", "id" },
                values: new object[] { new DateTime(2024, 6, 13, 8, 39, 11, 588, DateTimeKind.Utc).AddTicks(1513), 0 });

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumns: new[] { "doctor_id", "patient_id" },
                keyValues: new object[] { 3, 3 },
                columns: new[] { "bookings", "id" },
                values: new object[] { new DateTime(2024, 6, 13, 8, 39, 11, 588, DateTimeKind.Utc).AddTicks(1509), 0 });

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumns: new[] { "doctor_id", "patient_id" },
                keyValues: new object[] { 4, 1 },
                columns: new[] { "bookings", "id" },
                values: new object[] { new DateTime(2024, 6, 13, 8, 39, 11, 588, DateTimeKind.Utc).AddTicks(1515), 0 });

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumns: new[] { "doctor_id", "patient_id" },
                keyValues: new object[] { 4, 4 },
                columns: new[] { "bookings", "id" },
                values: new object[] { new DateTime(2024, 6, 13, 8, 39, 11, 588, DateTimeKind.Utc).AddTicks(1510), 0 });
        }
    }
}
