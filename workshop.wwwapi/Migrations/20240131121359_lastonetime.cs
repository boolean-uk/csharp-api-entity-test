using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class lastonetime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "appointment",
                keyColumns: new[] { "doctorid", "patientid" },
                keyValues: new object[] { 1, 1 },
                column: "booking",
                value: new DateTime(2024, 1, 31, 12, 13, 59, 506, DateTimeKind.Utc).AddTicks(3091));

            migrationBuilder.UpdateData(
                table: "appointment",
                keyColumns: new[] { "doctorid", "patientid" },
                keyValues: new object[] { 2, 1 },
                column: "booking",
                value: new DateTime(2024, 1, 31, 12, 13, 59, 506, DateTimeKind.Utc).AddTicks(3094));

            migrationBuilder.UpdateData(
                table: "appointment",
                keyColumns: new[] { "doctorid", "patientid" },
                keyValues: new object[] { 1, 2 },
                column: "booking",
                value: new DateTime(2024, 1, 31, 12, 13, 59, 506, DateTimeKind.Utc).AddTicks(3093));

            migrationBuilder.UpdateData(
                table: "appointment",
                keyColumns: new[] { "doctorid", "patientid" },
                keyValues: new object[] { 2, 2 },
                column: "booking",
                value: new DateTime(2024, 1, 31, 12, 13, 59, 506, DateTimeKind.Utc).AddTicks(3095));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "appointment",
                keyColumns: new[] { "doctorid", "patientid" },
                keyValues: new object[] { 1, 1 },
                column: "booking",
                value: new DateTime(2024, 1, 31, 12, 7, 5, 517, DateTimeKind.Utc).AddTicks(164));

            migrationBuilder.UpdateData(
                table: "appointment",
                keyColumns: new[] { "doctorid", "patientid" },
                keyValues: new object[] { 2, 1 },
                column: "booking",
                value: new DateTime(2024, 1, 31, 12, 7, 5, 517, DateTimeKind.Utc).AddTicks(168));

            migrationBuilder.UpdateData(
                table: "appointment",
                keyColumns: new[] { "doctorid", "patientid" },
                keyValues: new object[] { 1, 2 },
                column: "booking",
                value: new DateTime(2024, 1, 31, 12, 7, 5, 517, DateTimeKind.Utc).AddTicks(167));

            migrationBuilder.UpdateData(
                table: "appointment",
                keyColumns: new[] { "doctorid", "patientid" },
                keyValues: new object[] { 2, 2 },
                column: "booking",
                value: new DateTime(2024, 1, 31, 12, 7, 5, 517, DateTimeKind.Utc).AddTicks(169));
        }
    }
}
