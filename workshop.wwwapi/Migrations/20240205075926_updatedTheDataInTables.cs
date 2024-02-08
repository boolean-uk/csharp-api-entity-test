using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class updatedTheDataInTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_appointment",
                table: "appointment");

            migrationBuilder.DropIndex(
                name: "IX_appointment_doctor_id",
                table: "appointment");

            migrationBuilder.DeleteData(
                table: "appointment",
                keyColumns: new[] { "booking", "doctor_id", "patient_id" },
                keyValues: new object[] { new DateTime(2024, 1, 31, 14, 4, 5, 863, DateTimeKind.Utc).AddTicks(2880), 2, 1 });

            migrationBuilder.AddPrimaryKey(
                name: "PK_appointment",
                table: "appointment",
                columns: new[] { "doctor_id", "patient_id" });

            migrationBuilder.InsertData(
                table: "appointment",
                columns: new[] { "doctor_id", "patient_id", "booking" },
                values: new object[] { 2, 1, new DateTime(2024, 2, 5, 7, 59, 25, 813, DateTimeKind.Utc).AddTicks(5087) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_appointment",
                table: "appointment");

            migrationBuilder.DeleteData(
                table: "appointment",
                keyColumns: new[] { "doctor_id", "patient_id" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.AddPrimaryKey(
                name: "PK_appointment",
                table: "appointment",
                columns: new[] { "booking", "doctor_id", "patient_id" });

            migrationBuilder.InsertData(
                table: "appointment",
                columns: new[] { "booking", "doctor_id", "patient_id" },
                values: new object[] { new DateTime(2024, 1, 31, 14, 4, 5, 863, DateTimeKind.Utc).AddTicks(2880), 2, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_appointment_doctor_id",
                table: "appointment",
                column: "doctor_id");
        }
    }
}
