using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class AppointmentType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "type",
                table: "appointments",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumns: new[] { "doctorid", "patientid" },
                keyValues: new object[] { 1, 1 },
                columns: new[] { "booking_time", "type" },
                values: new object[] { new DateTime(2024, 2, 2, 10, 9, 36, 527, DateTimeKind.Utc).AddTicks(100), 0 });

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumns: new[] { "doctorid", "patientid" },
                keyValues: new object[] { 2, 2 },
                columns: new[] { "booking_time", "type" },
                values: new object[] { new DateTime(2024, 2, 2, 10, 9, 36, 527, DateTimeKind.Utc).AddTicks(102), 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "type",
                table: "appointments");

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumns: new[] { "doctorid", "patientid" },
                keyValues: new object[] { 1, 1 },
                column: "booking_time",
                value: new DateTime(2024, 2, 2, 7, 43, 28, 696, DateTimeKind.Utc).AddTicks(3365));

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumns: new[] { "doctorid", "patientid" },
                keyValues: new object[] { 2, 2 },
                column: "booking_time",
                value: new DateTime(2024, 2, 2, 7, 43, 28, 696, DateTimeKind.Utc).AddTicks(3366));
        }
    }
}
