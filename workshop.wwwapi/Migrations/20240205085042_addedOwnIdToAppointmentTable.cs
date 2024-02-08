using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class addedOwnIdToAppointmentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_appointment",
                table: "appointment");

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
                keyValues: new object[] { 2, 1 });

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

            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "appointment",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_appointment",
                table: "appointment",
                columns: new[] { "id", "doctor_id", "patient_id" });

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

            migrationBuilder.CreateIndex(
                name: "IX_appointment_doctor_id",
                table: "appointment",
                column: "doctor_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_appointment",
                table: "appointment");

            migrationBuilder.DropIndex(
                name: "IX_appointment_doctor_id",
                table: "appointment");

            migrationBuilder.DeleteData(
                table: "appointment",
                keyColumns: new[] { "doctor_id", "patient_id", "id" },
                keyColumnTypes: new[] { "integer", "integer", "integer" },
                keyValues: new object[] { 1, 1, 0 });

            migrationBuilder.DeleteData(
                table: "appointment",
                keyColumns: new[] { "doctor_id", "patient_id", "id" },
                keyColumnTypes: new[] { "integer", "integer", "integer" },
                keyValues: new object[] { 1, 2, 0 });

            migrationBuilder.DeleteData(
                table: "appointment",
                keyColumns: new[] { "doctor_id", "patient_id", "id" },
                keyColumnTypes: new[] { "integer", "integer", "integer" },
                keyValues: new object[] { 2, 1, 0 });

            migrationBuilder.DeleteData(
                table: "appointment",
                keyColumns: new[] { "doctor_id", "patient_id", "id" },
                keyColumnTypes: new[] { "integer", "integer", "integer" },
                keyValues: new object[] { 2, 3, 0 });

            migrationBuilder.DeleteData(
                table: "appointment",
                keyColumns: new[] { "doctor_id", "patient_id", "id" },
                keyColumnTypes: new[] { "integer", "integer", "integer" },
                keyValues: new object[] { 3, 2, 0 });

            migrationBuilder.DeleteData(
                table: "appointment",
                keyColumns: new[] { "doctor_id", "patient_id", "id" },
                keyColumnTypes: new[] { "integer", "integer", "integer" },
                keyValues: new object[] { 3, 3, 0 });

            migrationBuilder.DropColumn(
                name: "id",
                table: "appointment");

            migrationBuilder.AddPrimaryKey(
                name: "PK_appointment",
                table: "appointment",
                columns: new[] { "doctor_id", "patient_id" });

            migrationBuilder.InsertData(
                table: "appointment",
                columns: new[] { "doctor_id", "patient_id", "booking" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 2, 5, 8, 8, 10, 973, DateTimeKind.Utc).AddTicks(7764) },
                    { 1, 2, new DateTime(2024, 2, 5, 8, 8, 10, 973, DateTimeKind.Utc).AddTicks(7764) },
                    { 2, 1, new DateTime(2024, 2, 5, 8, 8, 10, 973, DateTimeKind.Utc).AddTicks(7764) },
                    { 2, 3, new DateTime(2024, 2, 5, 8, 8, 10, 973, DateTimeKind.Utc).AddTicks(7764) },
                    { 3, 2, new DateTime(2024, 2, 5, 8, 8, 10, 973, DateTimeKind.Utc).AddTicks(7764) },
                    { 3, 3, new DateTime(2024, 2, 5, 8, 8, 10, 973, DateTimeKind.Utc).AddTicks(7764) }
                });
        }
    }
}
