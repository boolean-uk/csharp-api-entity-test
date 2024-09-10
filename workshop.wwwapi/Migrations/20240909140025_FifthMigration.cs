using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class FifthMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DoctorName",
                table: "appointments");

            migrationBuilder.DropColumn(
                name: "PatientName",
                table: "appointments");

            migrationBuilder.InsertData(
                table: "doctors",
                columns: new[] { "id", "fullName" },
                values: new object[,]
                {
                    { 1, "John Doe" },
                    { 2, "Jane Doe" }
                });

            migrationBuilder.InsertData(
                table: "patients",
                columns: new[] { "id", "fullName" },
                values: new object[,]
                {
                    { 1, "Brian Smith" },
                    { 2, "Anne Wayne" }
                });

            migrationBuilder.InsertData(
                table: "appointments",
                columns: new[] { "DoctorId", "PatientId", "booking" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 9, 9, 14, 0, 25, 95, DateTimeKind.Utc).AddTicks(5921) },
                    { 2, 2, new DateTime(2024, 9, 9, 14, 0, 25, 95, DateTimeKind.Utc).AddTicks(5925) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "DoctorId", "PatientId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "DoctorId", "PatientId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "patients",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "patients",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.AddColumn<string>(
                name: "DoctorName",
                table: "appointments",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PatientName",
                table: "appointments",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
