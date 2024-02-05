using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class AppointmentSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "doctors",
                columns: new[] { "id", "fullname" },
                values: new object[,]
                {
                    { 1, "Doctor Who" },
                    { 2, "Doctor Why" }
                });

            migrationBuilder.InsertData(
                table: "appointments",
                columns: new[] { "doctorid", "patientid", "booking_time" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 2, 2, 7, 43, 28, 696, DateTimeKind.Utc).AddTicks(3365) },
                    { 2, 2, new DateTime(2024, 2, 2, 7, 43, 28, 696, DateTimeKind.Utc).AddTicks(3366) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorid", "patientid" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorid", "patientid" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 2);
        }
    }
}
