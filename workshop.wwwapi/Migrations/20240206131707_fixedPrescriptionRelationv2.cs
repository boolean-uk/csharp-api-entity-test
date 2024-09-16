using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class fixedPrescriptionRelationv2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "instructions",
                table: "prescription");

            migrationBuilder.RenameColumn(
                name: "quantiy",
                table: "medicine",
                newName: "quantity");

            migrationBuilder.AddColumn<string>(
                name: "instructions",
                table: "medicine",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "appointment",
                keyColumns: new[] { "doctor_id", "patient_id" },
                keyValues: new object[] { 1, 1 },
                column: "booking",
                value: new DateTime(2024, 2, 7, 13, 17, 7, 234, DateTimeKind.Utc).AddTicks(8190));

            migrationBuilder.UpdateData(
                table: "appointment",
                keyColumns: new[] { "doctor_id", "patient_id" },
                keyValues: new object[] { 1, 2 },
                column: "booking",
                value: new DateTime(2024, 2, 8, 13, 17, 7, 234, DateTimeKind.Utc).AddTicks(8201));

            migrationBuilder.UpdateData(
                table: "appointment",
                keyColumns: new[] { "doctor_id", "patient_id" },
                keyValues: new object[] { 2, 3 },
                column: "booking",
                value: new DateTime(2024, 2, 9, 13, 17, 7, 234, DateTimeKind.Utc).AddTicks(8202));

            migrationBuilder.UpdateData(
                table: "medicine",
                keyColumn: "id",
                keyValue: 1,
                column: "instructions",
                value: "Take one each morning, avoid swallowing for 1 minute and drinking for 5 minutes.");

            migrationBuilder.UpdateData(
                table: "medicine",
                keyColumn: "id",
                keyValue: 2,
                column: "instructions",
                value: "Take as many as u like, avoid alcohol while taking these, or dont, I am not liable anyway.");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "instructions",
                table: "medicine");

            migrationBuilder.RenameColumn(
                name: "quantity",
                table: "medicine",
                newName: "quantiy");

            migrationBuilder.AddColumn<string>(
                name: "instructions",
                table: "prescription",
                type: "text",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.UpdateData(
                table: "prescription",
                keyColumn: "id",
                keyValue: 1,
                column: "instructions",
                value: "Take one each morning, avoid swallowing for 1 minute and drinking for 5 minutes.");

            migrationBuilder.UpdateData(
                table: "prescription",
                keyColumn: "id",
                keyValue: 2,
                column: "instructions",
                value: "Take as many as u like, avoid alcohol while taking these, or dont, I am not liable anyway.");
        }
    }
}
