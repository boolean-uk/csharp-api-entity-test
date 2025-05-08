using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class AppointmentId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "appointments",
                type: "integer",
                nullable: false,
                defaultValue: 0);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "id",
                table: "appointments");

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
    }
}
