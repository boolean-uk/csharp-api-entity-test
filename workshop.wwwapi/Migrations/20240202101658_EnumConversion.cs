using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class EnumConversion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "type",
                table: "appointments",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumns: new[] { "doctorid", "patientid" },
                keyValues: new object[] { 1, 1 },
                columns: new[] { "booking_time", "type" },
                values: new object[] { new DateTime(2024, 2, 2, 10, 16, 58, 440, DateTimeKind.Utc).AddTicks(5826), "Online" });

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumns: new[] { "doctorid", "patientid" },
                keyValues: new object[] { 2, 2 },
                columns: new[] { "booking_time", "type" },
                values: new object[] { new DateTime(2024, 2, 2, 10, 16, 58, 440, DateTimeKind.Utc).AddTicks(5828), "InPerson" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "type",
                table: "appointments",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

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
    }
}
