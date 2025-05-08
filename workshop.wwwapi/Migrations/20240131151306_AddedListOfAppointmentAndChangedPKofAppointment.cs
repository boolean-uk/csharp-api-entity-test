using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class AddedListOfAppointmentAndChangedPKofAppointment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_appointments",
                table: "appointments");

            migrationBuilder.DropIndex(
                name: "IX_appointments_patient_id",
                table: "appointments");

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "booking", "doctor_id", "patient_id" },
                keyValues: new object[] { new DateTime(2024, 1, 31, 13, 0, 33, 114, DateTimeKind.Utc).AddTicks(9296), 1, 1 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "booking", "doctor_id", "patient_id" },
                keyValues: new object[] { new DateTime(2024, 1, 31, 13, 0, 33, 114, DateTimeKind.Utc).AddTicks(9296), 3, 4 });

            migrationBuilder.AddPrimaryKey(
                name: "PK_appointments",
                table: "appointments",
                columns: new[] { "patient_id", "doctor_id" });

            migrationBuilder.InsertData(
                table: "appointments",
                columns: new[] { "doctor_id", "patient_id", "booking" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 1, 31, 15, 13, 5, 773, DateTimeKind.Utc).AddTicks(7048) },
                    { 3, 4, new DateTime(2024, 1, 31, 15, 13, 5, 773, DateTimeKind.Utc).AddTicks(7048) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_appointments",
                table: "appointments");

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctor_id", "patient_id" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctor_id", "patient_id" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.AddPrimaryKey(
                name: "PK_appointments",
                table: "appointments",
                columns: new[] { "booking", "patient_id", "doctor_id" });

            migrationBuilder.InsertData(
                table: "appointments",
                columns: new[] { "booking", "doctor_id", "patient_id" },
                values: new object[,]
                {
                    { new DateTime(2024, 1, 31, 13, 0, 33, 114, DateTimeKind.Utc).AddTicks(9296), 1, 1 },
                    { new DateTime(2024, 1, 31, 13, 0, 33, 114, DateTimeKind.Utc).AddTicks(9296), 3, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_appointments_patient_id",
                table: "appointments",
                column: "patient_id");
        }
    }
}
