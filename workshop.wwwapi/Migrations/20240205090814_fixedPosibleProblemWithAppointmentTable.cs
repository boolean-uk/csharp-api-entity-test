using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class fixedPosibleProblemWithAppointmentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "appointment",
                keyColumns: new[] { "doctor_id", "patient_id", "id" },
                keyValues: new object[] { 1, 1, 0 });

            migrationBuilder.DeleteData(
                table: "appointment",
                keyColumns: new[] { "doctor_id", "patient_id", "id" },
                keyValues: new object[] { 1, 2, 0 });

            migrationBuilder.DeleteData(
                table: "appointment",
                keyColumns: new[] { "doctor_id", "patient_id", "id" },
                keyValues: new object[] { 2, 1, 0 });

            migrationBuilder.DeleteData(
                table: "appointment",
                keyColumns: new[] { "doctor_id", "patient_id", "id" },
                keyValues: new object[] { 2, 3, 0 });

            migrationBuilder.DeleteData(
                table: "appointment",
                keyColumns: new[] { "doctor_id", "patient_id", "id" },
                keyValues: new object[] { 3, 2, 0 });

            migrationBuilder.DeleteData(
                table: "appointment",
                keyColumns: new[] { "doctor_id", "patient_id", "id" },
                keyValues: new object[] { 3, 3, 0 });

            migrationBuilder.InsertData(
                table: "appointment",
                columns: new[] { "doctor_id", "patient_id", "id", "booking" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2024, 2, 5, 9, 8, 14, 205, DateTimeKind.Utc).AddTicks(4237) },
                    { 1, 2, 2, new DateTime(2024, 2, 5, 9, 8, 14, 205, DateTimeKind.Utc).AddTicks(4237) },
                    { 2, 3, 3, new DateTime(2024, 2, 5, 9, 8, 14, 205, DateTimeKind.Utc).AddTicks(4237) },
                    { 2, 1, 4, new DateTime(2024, 2, 5, 9, 8, 14, 205, DateTimeKind.Utc).AddTicks(4237) },
                    { 3, 2, 5, new DateTime(2024, 2, 5, 9, 8, 14, 205, DateTimeKind.Utc).AddTicks(4237) },
                    { 3, 3, 6, new DateTime(2024, 2, 5, 9, 8, 14, 205, DateTimeKind.Utc).AddTicks(4237) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "appointment",
                keyColumns: new[] { "doctor_id", "patient_id", "id" },
                keyValues: new object[] { 1, 1, 1 });

            migrationBuilder.DeleteData(
                table: "appointment",
                keyColumns: new[] { "doctor_id", "patient_id", "id" },
                keyValues: new object[] { 1, 2, 2 });

            migrationBuilder.DeleteData(
                table: "appointment",
                keyColumns: new[] { "doctor_id", "patient_id", "id" },
                keyValues: new object[] { 2, 3, 3 });

            migrationBuilder.DeleteData(
                table: "appointment",
                keyColumns: new[] { "doctor_id", "patient_id", "id" },
                keyValues: new object[] { 2, 1, 4 });

            migrationBuilder.DeleteData(
                table: "appointment",
                keyColumns: new[] { "doctor_id", "patient_id", "id" },
                keyValues: new object[] { 3, 2, 5 });

            migrationBuilder.DeleteData(
                table: "appointment",
                keyColumns: new[] { "doctor_id", "patient_id", "id" },
                keyValues: new object[] { 3, 3, 6 });

            migrationBuilder.InsertData(
                table: "appointment",
                columns: new[] { "doctor_id", "patient_id", "id", "booking" },
                values: new object[,]
                {
                    { 1, 1, 0, new DateTime(2024, 2, 5, 8, 50, 41, 529, DateTimeKind.Utc).AddTicks(1026) },
                    { 1, 2, 0, new DateTime(2024, 2, 5, 8, 50, 41, 529, DateTimeKind.Utc).AddTicks(1026) },
                    { 2, 1, 0, new DateTime(2024, 2, 5, 8, 50, 41, 529, DateTimeKind.Utc).AddTicks(1026) },
                    { 2, 3, 0, new DateTime(2024, 2, 5, 8, 50, 41, 529, DateTimeKind.Utc).AddTicks(1026) },
                    { 3, 2, 0, new DateTime(2024, 2, 5, 8, 50, 41, 529, DateTimeKind.Utc).AddTicks(1026) },
                    { 3, 3, 0, new DateTime(2024, 2, 5, 8, 50, 41, 529, DateTimeKind.Utc).AddTicks(1026) }
                });
        }
    }
}
