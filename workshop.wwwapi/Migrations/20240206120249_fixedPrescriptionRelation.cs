using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class fixedPrescriptionRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "appointment",
                keyColumns: new[] { "doctor_id", "patient_id" },
                keyValues: new object[] { 1, 1 },
                column: "booking",
                value: new DateTime(2024, 2, 7, 12, 2, 49, 160, DateTimeKind.Utc).AddTicks(8751));

            migrationBuilder.UpdateData(
                table: "appointment",
                keyColumns: new[] { "doctor_id", "patient_id" },
                keyValues: new object[] { 1, 2 },
                column: "booking",
                value: new DateTime(2024, 2, 8, 12, 2, 49, 160, DateTimeKind.Utc).AddTicks(8760));

            migrationBuilder.UpdateData(
                table: "appointment",
                keyColumns: new[] { "doctor_id", "patient_id" },
                keyValues: new object[] { 2, 3 },
                column: "booking",
                value: new DateTime(2024, 2, 9, 12, 2, 49, 160, DateTimeKind.Utc).AddTicks(8761));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "appointment",
                keyColumns: new[] { "doctor_id", "patient_id" },
                keyValues: new object[] { 1, 1 },
                column: "booking",
                value: new DateTime(2024, 2, 6, 14, 11, 17, 374, DateTimeKind.Utc).AddTicks(3273));

            migrationBuilder.UpdateData(
                table: "appointment",
                keyColumns: new[] { "doctor_id", "patient_id" },
                keyValues: new object[] { 1, 2 },
                column: "booking",
                value: new DateTime(2024, 2, 7, 14, 11, 17, 374, DateTimeKind.Utc).AddTicks(3282));

            migrationBuilder.UpdateData(
                table: "appointment",
                keyColumns: new[] { "doctor_id", "patient_id" },
                keyValues: new object[] { 2, 3 },
                column: "booking",
                value: new DateTime(2024, 2, 8, 14, 11, 17, 374, DateTimeKind.Utc).AddTicks(3283));
        }
    }
}
