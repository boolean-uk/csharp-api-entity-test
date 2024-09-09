using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class AddPredMed3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PrescriptionId",
                table: "appointment",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "appointment",
                keyColumns: new[] { "date", "DoctorId", "PatientId" },
                keyValues: new object[] { new DateTime(1998, 10, 12, 12, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                column: "PrescriptionId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "appointment",
                keyColumns: new[] { "date", "DoctorId", "PatientId" },
                keyValues: new object[] { new DateTime(1999, 10, 12, 12, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                column: "PrescriptionId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "appointment",
                keyColumns: new[] { "date", "DoctorId", "PatientId" },
                keyValues: new object[] { new DateTime(1997, 10, 12, 12, 0, 0, 0, DateTimeKind.Unspecified), 2, 2 },
                column: "PrescriptionId",
                value: 3);

            migrationBuilder.CreateIndex(
                name: "IX_appointment_PrescriptionId",
                table: "appointment",
                column: "PrescriptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_appointment_prescription_PrescriptionId",
                table: "appointment",
                column: "PrescriptionId",
                principalTable: "prescription",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_appointment_prescription_PrescriptionId",
                table: "appointment");

            migrationBuilder.DropIndex(
                name: "IX_appointment_PrescriptionId",
                table: "appointment");

            migrationBuilder.DropColumn(
                name: "PrescriptionId",
                table: "appointment");
        }
    }
}
