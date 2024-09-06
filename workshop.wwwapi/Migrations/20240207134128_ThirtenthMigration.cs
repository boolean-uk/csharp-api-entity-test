using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class ThirtenthMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumns: new[] { "doctorid", "patientid" },
                keyValues: new object[] { 1, 1 },
                column: "booking",
                value: new DateTime(2024, 2, 8, 13, 41, 28, 12, DateTimeKind.Utc).AddTicks(1271));

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumns: new[] { "doctorid", "patientid" },
                keyValues: new object[] { 2, 2 },
                column: "booking",
                value: new DateTime(2024, 2, 9, 13, 41, 28, 12, DateTimeKind.Utc).AddTicks(1308));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumns: new[] { "doctorid", "patientid" },
                keyValues: new object[] { 1, 1 },
                column: "booking",
                value: new DateTime(2024, 2, 8, 8, 29, 51, 391, DateTimeKind.Utc).AddTicks(1576));

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumns: new[] { "doctorid", "patientid" },
                keyValues: new object[] { 2, 2 },
                column: "booking",
                value: new DateTime(2024, 2, 9, 8, 29, 51, 391, DateTimeKind.Utc).AddTicks(1590));
        }
    }
}
