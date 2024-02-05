using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class updatedTheDataInTablesAgain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "appointment",
                keyColumns: new[] { "doctor_id", "patient_id" },
                keyValues: new object[] { 2, 1 },
                column: "booking",
                value: new DateTime(2024, 2, 5, 8, 8, 10, 973, DateTimeKind.Utc).AddTicks(7764));

            migrationBuilder.InsertData(
                table: "appointment",
                columns: new[] { "doctor_id", "patient_id", "booking" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 2, 5, 8, 8, 10, 973, DateTimeKind.Utc).AddTicks(7764) },
                    { 1, 2, new DateTime(2024, 2, 5, 8, 8, 10, 973, DateTimeKind.Utc).AddTicks(7764) },
                    { 2, 3, new DateTime(2024, 2, 5, 8, 8, 10, 973, DateTimeKind.Utc).AddTicks(7764) },
                    { 3, 2, new DateTime(2024, 2, 5, 8, 8, 10, 973, DateTimeKind.Utc).AddTicks(7764) },
                    { 3, 3, new DateTime(2024, 2, 5, 8, 8, 10, 973, DateTimeKind.Utc).AddTicks(7764) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "appointment",
                keyColumns: new[] { "doctor_id", "patient_id" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "appointment",
                keyColumns: new[] { "doctor_id", "patient_id" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "appointment",
                keyColumns: new[] { "doctor_id", "patient_id" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "appointment",
                keyColumns: new[] { "doctor_id", "patient_id" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "appointment",
                keyColumns: new[] { "doctor_id", "patient_id" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.UpdateData(
                table: "appointment",
                keyColumns: new[] { "doctor_id", "patient_id" },
                keyValues: new object[] { 2, 1 },
                column: "booking",
                value: new DateTime(2024, 2, 5, 7, 59, 25, 813, DateTimeKind.Utc).AddTicks(5087));
        }
    }
}
