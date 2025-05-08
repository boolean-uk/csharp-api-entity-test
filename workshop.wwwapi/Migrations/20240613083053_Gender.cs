using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class Gender : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "bijnaam",
                table: "patients",
                newName: "gender");

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumns: new[] { "doctor_id", "patient_id" },
                keyValues: new object[] { 1, 1 },
                column: "bookings",
                value: new DateTime(2024, 6, 13, 8, 30, 53, 269, DateTimeKind.Utc).AddTicks(2618));

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumns: new[] { "doctor_id", "patient_id" },
                keyValues: new object[] { 1, 4 },
                column: "bookings",
                value: new DateTime(2024, 6, 13, 8, 30, 53, 269, DateTimeKind.Utc).AddTicks(2625));

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumns: new[] { "doctor_id", "patient_id" },
                keyValues: new object[] { 2, 2 },
                column: "bookings",
                value: new DateTime(2024, 6, 13, 8, 30, 53, 269, DateTimeKind.Utc).AddTicks(2622));

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumns: new[] { "doctor_id", "patient_id" },
                keyValues: new object[] { 2, 3 },
                column: "bookings",
                value: new DateTime(2024, 6, 13, 8, 30, 53, 269, DateTimeKind.Utc).AddTicks(2626));

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumns: new[] { "doctor_id", "patient_id" },
                keyValues: new object[] { 3, 2 },
                column: "bookings",
                value: new DateTime(2024, 6, 13, 8, 30, 53, 269, DateTimeKind.Utc).AddTicks(2627));

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumns: new[] { "doctor_id", "patient_id" },
                keyValues: new object[] { 3, 3 },
                column: "bookings",
                value: new DateTime(2024, 6, 13, 8, 30, 53, 269, DateTimeKind.Utc).AddTicks(2623));

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumns: new[] { "doctor_id", "patient_id" },
                keyValues: new object[] { 4, 1 },
                column: "bookings",
                value: new DateTime(2024, 6, 13, 8, 30, 53, 269, DateTimeKind.Utc).AddTicks(2628));

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumns: new[] { "doctor_id", "patient_id" },
                keyValues: new object[] { 4, 4 },
                column: "bookings",
                value: new DateTime(2024, 6, 13, 8, 30, 53, 269, DateTimeKind.Utc).AddTicks(2624));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "gender",
                table: "patients",
                newName: "bijnaam");

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumns: new[] { "doctor_id", "patient_id" },
                keyValues: new object[] { 1, 1 },
                column: "bookings",
                value: new DateTime(2024, 6, 13, 8, 28, 32, 579, DateTimeKind.Utc).AddTicks(6508));

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumns: new[] { "doctor_id", "patient_id" },
                keyValues: new object[] { 1, 4 },
                column: "bookings",
                value: new DateTime(2024, 6, 13, 8, 28, 32, 579, DateTimeKind.Utc).AddTicks(6520));

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumns: new[] { "doctor_id", "patient_id" },
                keyValues: new object[] { 2, 2 },
                column: "bookings",
                value: new DateTime(2024, 6, 13, 8, 28, 32, 579, DateTimeKind.Utc).AddTicks(6517));

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumns: new[] { "doctor_id", "patient_id" },
                keyValues: new object[] { 2, 3 },
                column: "bookings",
                value: new DateTime(2024, 6, 13, 8, 28, 32, 579, DateTimeKind.Utc).AddTicks(6522));

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumns: new[] { "doctor_id", "patient_id" },
                keyValues: new object[] { 3, 2 },
                column: "bookings",
                value: new DateTime(2024, 6, 13, 8, 28, 32, 579, DateTimeKind.Utc).AddTicks(6523));

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumns: new[] { "doctor_id", "patient_id" },
                keyValues: new object[] { 3, 3 },
                column: "bookings",
                value: new DateTime(2024, 6, 13, 8, 28, 32, 579, DateTimeKind.Utc).AddTicks(6518));

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumns: new[] { "doctor_id", "patient_id" },
                keyValues: new object[] { 4, 1 },
                column: "bookings",
                value: new DateTime(2024, 6, 13, 8, 28, 32, 579, DateTimeKind.Utc).AddTicks(6524));

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumns: new[] { "doctor_id", "patient_id" },
                keyValues: new object[] { 4, 4 },
                column: "bookings",
                value: new DateTime(2024, 6, 13, 8, 28, 32, 579, DateTimeKind.Utc).AddTicks(6519));
        }
    }
}
