using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class tryagain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "appointment",
                keyColumns: new[] { "doctorid", "patientid" },
                keyValues: new object[] { 1, 1 },
                column: "booking",
                value: new DateTime(2024, 1, 31, 12, 4, 56, 310, DateTimeKind.Utc).AddTicks(6270));

            migrationBuilder.UpdateData(
                table: "appointment",
                keyColumns: new[] { "doctorid", "patientid" },
                keyValues: new object[] { 2, 1 },
                column: "booking",
                value: new DateTime(2024, 1, 31, 12, 4, 56, 310, DateTimeKind.Utc).AddTicks(6308));

            migrationBuilder.UpdateData(
                table: "appointment",
                keyColumns: new[] { "doctorid", "patientid" },
                keyValues: new object[] { 1, 2 },
                column: "booking",
                value: new DateTime(2024, 1, 31, 12, 4, 56, 310, DateTimeKind.Utc).AddTicks(6272));

            migrationBuilder.UpdateData(
                table: "appointment",
                keyColumns: new[] { "doctorid", "patientid" },
                keyValues: new object[] { 2, 2 },
                column: "booking",
                value: new DateTime(2024, 1, 31, 12, 4, 56, 310, DateTimeKind.Utc).AddTicks(6309));
        }
    }
}
