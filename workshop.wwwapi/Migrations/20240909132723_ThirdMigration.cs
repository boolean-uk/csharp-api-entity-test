using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class ThirdMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "DoctorId", "PatientId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "DoctorId", "PatientId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "DoctorId", "PatientId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "DoctorId", "PatientId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "DoctorId", "PatientId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "DoctorId", "PatientId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "DoctorId", "PatientId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "DoctorId", "PatientId" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "patients",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "patients",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "patients",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "patients",
                keyColumn: "id",
                keyValue: 4);

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

            migrationBuilder.CreateIndex(
                name: "IX_appointments_PatientId",
                table: "appointments",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_appointments_doctors_DoctorId",
                table: "appointments",
                column: "DoctorId",
                principalTable: "doctors",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_appointments_patients_PatientId",
                table: "appointments",
                column: "PatientId",
                principalTable: "patients",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_appointments_doctors_DoctorId",
                table: "appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_appointments_patients_PatientId",
                table: "appointments");

            migrationBuilder.DropIndex(
                name: "IX_appointments_PatientId",
                table: "appointments");

            migrationBuilder.DropColumn(
                name: "DoctorName",
                table: "appointments");

            migrationBuilder.DropColumn(
                name: "PatientName",
                table: "appointments");

            migrationBuilder.InsertData(
                table: "appointments",
                columns: new[] { "DoctorId", "PatientId", "booking" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 9, 9, 9, 43, 44, 201, DateTimeKind.Utc).AddTicks(1512) },
                    { 1, 4, new DateTime(2024, 9, 9, 9, 43, 44, 201, DateTimeKind.Utc).AddTicks(1517) },
                    { 2, 2, new DateTime(2024, 9, 9, 9, 43, 44, 201, DateTimeKind.Utc).AddTicks(1514) },
                    { 2, 3, new DateTime(2024, 9, 9, 9, 43, 44, 201, DateTimeKind.Utc).AddTicks(1518) },
                    { 3, 2, new DateTime(2024, 9, 9, 9, 43, 44, 201, DateTimeKind.Utc).AddTicks(1518) },
                    { 3, 3, new DateTime(2024, 9, 9, 9, 43, 44, 201, DateTimeKind.Utc).AddTicks(1515) },
                    { 4, 1, new DateTime(2024, 9, 9, 9, 43, 44, 201, DateTimeKind.Utc).AddTicks(1519) },
                    { 4, 4, new DateTime(2024, 9, 9, 9, 43, 44, 201, DateTimeKind.Utc).AddTicks(1516) }
                });

            migrationBuilder.InsertData(
                table: "doctors",
                columns: new[] { "id", "fullName" },
                values: new object[,]
                {
                    { 1, "John Doe" },
                    { 2, "Jane Doe" },
                    { 3, "John Smith" },
                    { 4, "Jane Smith" }
                });

            migrationBuilder.InsertData(
                table: "patients",
                columns: new[] { "id", "fullName" },
                values: new object[,]
                {
                    { 1, "Anna Drijver" },
                    { 2, "Tom Cruise" },
                    { 3, "Gerogina Verbaan" },
                    { 4, "Daan Schuurmans" }
                });
        }
    }
}
