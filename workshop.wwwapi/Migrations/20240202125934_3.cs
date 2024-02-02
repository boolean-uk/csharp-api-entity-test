using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class _3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PrescriptionId",
                table: "appointments",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Prescription",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    appointment_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescription", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Medicine",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    quantity = table.Column<int>(type: "integer", nullable: false),
                    notes = table.Column<string>(type: "text", nullable: false),
                    PrescriptionId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicine", x => x.id);
                    table.ForeignKey(
                        name: "FK_Medicine_Prescription_PrescriptionId",
                        column: x => x.PrescriptionId,
                        principalTable: "Prescription",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "PrescriptionMedicine",
                columns: table => new
                {
                    PrescriptionId = table.Column<int>(type: "integer", nullable: false),
                    MedicineId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrescriptionMedicine", x => new { x.PrescriptionId, x.MedicineId });
                    table.ForeignKey(
                        name: "FK_PrescriptionMedicine_Medicine_MedicineId",
                        column: x => x.MedicineId,
                        principalTable: "Medicine",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PrescriptionMedicine_Prescription_PrescriptionId",
                        column: x => x.PrescriptionId,
                        principalTable: "Prescription",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Medicine",
                columns: new[] { "id", "name", "notes", "PrescriptionId", "quantity" },
                values: new object[,]
                {
                    { 1, "Medicine A", "Take once daily", null, 10 },
                    { 2, "Medicine B", "Take twice daily", null, 20 }
                });

            migrationBuilder.InsertData(
                table: "Prescription",
                columns: new[] { "id", "appointment_id" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 }
                });

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumns: new[] { "doctor_id", "patient_id" },
                keyValues: new object[] { 1, 1 },
                columns: new[] { "booking", "PrescriptionId" },
                values: new object[] { new DateTime(2024, 2, 2, 12, 59, 34, 234, DateTimeKind.Utc).AddTicks(5151), null });

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumns: new[] { "doctor_id", "patient_id" },
                keyValues: new object[] { 2, 1 },
                columns: new[] { "booking", "PrescriptionId" },
                values: new object[] { new DateTime(2024, 2, 4, 12, 59, 34, 234, DateTimeKind.Utc).AddTicks(5166), null });

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumns: new[] { "doctor_id", "patient_id" },
                keyValues: new object[] { 1, 2 },
                columns: new[] { "booking", "PrescriptionId" },
                values: new object[] { new DateTime(2024, 2, 3, 12, 59, 34, 234, DateTimeKind.Utc).AddTicks(5154), null });

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumns: new[] { "doctor_id", "patient_id" },
                keyValues: new object[] { 2, 2 },
                columns: new[] { "booking", "PrescriptionId" },
                values: new object[] { new DateTime(2024, 2, 5, 12, 59, 34, 234, DateTimeKind.Utc).AddTicks(5167), null });

            migrationBuilder.InsertData(
                table: "PrescriptionMedicine",
                columns: new[] { "MedicineId", "PrescriptionId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 1, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_appointments_PrescriptionId",
                table: "appointments",
                column: "PrescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_appointments_doctor_id",
                table: "appointments",
                column: "doctor_id");

            migrationBuilder.CreateIndex(
                name: "IX_Medicine_PrescriptionId",
                table: "Medicine",
                column: "PrescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_PrescriptionMedicine_MedicineId",
                table: "PrescriptionMedicine",
                column: "MedicineId");

            migrationBuilder.AddForeignKey(
                name: "FK_appointments_Prescription_PrescriptionId",
                table: "appointments",
                column: "PrescriptionId",
                principalTable: "Prescription",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_appointments_doctors_doctor_id",
                table: "appointments",
                column: "doctor_id",
                principalTable: "doctors",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_appointments_patients_patient_id",
                table: "appointments",
                column: "patient_id",
                principalTable: "patients",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_appointments_Prescription_PrescriptionId",
                table: "appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_appointments_doctors_doctor_id",
                table: "appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_appointments_patients_patient_id",
                table: "appointments");

            migrationBuilder.DropTable(
                name: "PrescriptionMedicine");

            migrationBuilder.DropTable(
                name: "Medicine");

            migrationBuilder.DropTable(
                name: "Prescription");

            migrationBuilder.DropIndex(
                name: "IX_appointments_PrescriptionId",
                table: "appointments");

            migrationBuilder.DropIndex(
                name: "IX_appointments_doctor_id",
                table: "appointments");

            migrationBuilder.DropColumn(
                name: "PrescriptionId",
                table: "appointments");

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumns: new[] { "doctor_id", "patient_id" },
                keyValues: new object[] { 1, 1 },
                column: "booking",
                value: new DateTime(2024, 2, 2, 7, 40, 46, 439, DateTimeKind.Utc).AddTicks(4065));

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumns: new[] { "doctor_id", "patient_id" },
                keyValues: new object[] { 2, 1 },
                column: "booking",
                value: new DateTime(2024, 2, 4, 7, 40, 46, 439, DateTimeKind.Utc).AddTicks(4077));

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumns: new[] { "doctor_id", "patient_id" },
                keyValues: new object[] { 1, 2 },
                column: "booking",
                value: new DateTime(2024, 2, 3, 7, 40, 46, 439, DateTimeKind.Utc).AddTicks(4068));

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumns: new[] { "doctor_id", "patient_id" },
                keyValues: new object[] { 2, 2 },
                column: "booking",
                value: new DateTime(2024, 2, 5, 7, 40, 46, 439, DateTimeKind.Utc).AddTicks(4078));
        }
    }
}
