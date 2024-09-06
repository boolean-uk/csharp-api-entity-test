using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class DbMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "doctors",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_doctors", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "medicines",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    quantity = table.Column<int>(type: "integer", nullable: false),
                    instructions = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medicines", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "patients",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patients", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "appointments",
                columns: table => new
                {
                    booking = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    doctor_id = table.Column<int>(type: "integer", nullable: false),
                    patient_id = table.Column<int>(type: "integer", nullable: false),
                    prescription_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_appointments", x => new { x.booking, x.patient_id, x.doctor_id });
                    table.ForeignKey(
                        name: "FK_appointments_doctors_doctor_id",
                        column: x => x.doctor_id,
                        principalTable: "doctors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_appointments_patients_patient_id",
                        column: x => x.patient_id,
                        principalTable: "patients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "prescriptions",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AppointmentBooking = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    AppointmentDoctorId = table.Column<int>(type: "integer", nullable: true),
                    AppointmentPatientId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_prescriptions", x => x.id);
                    table.ForeignKey(
                        name: "FK_prescriptions_appointments_AppointmentBooking_AppointmentPa~",
                        columns: x => new { x.AppointmentBooking, x.AppointmentPatientId, x.AppointmentDoctorId },
                        principalTable: "appointments",
                        principalColumns: new[] { "booking", "patient_id", "doctor_id" });
                });

            migrationBuilder.CreateTable(
                name: "PrescriptionMedicines",
                columns: table => new
                {
                    MedicinesId = table.Column<int>(type: "integer", nullable: false),
                    PrescriptionsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrescriptionMedicines", x => new { x.MedicinesId, x.PrescriptionsId });
                    table.ForeignKey(
                        name: "FK_PrescriptionMedicines_medicines_MedicinesId",
                        column: x => x.MedicinesId,
                        principalTable: "medicines",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PrescriptionMedicines_prescriptions_PrescriptionsId",
                        column: x => x.PrescriptionsId,
                        principalTable: "prescriptions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "doctors",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "Doctor Phil" },
                    { 2, "Doctor Jim" },
                    { 3, "Doctor R2D2" }
                });

            migrationBuilder.InsertData(
                table: "medicines",
                columns: new[] { "id", "instructions", "name", "quantity" },
                values: new object[,]
                {
                    { 1, "Take with water", "Medicine A", 10 },
                    { 2, "Take before meals", "Medicine B", 20 }
                });

            migrationBuilder.InsertData(
                table: "patients",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "Nigel" },
                    { 2, "AJ" },
                    { 3, "Kevin" }
                });

            migrationBuilder.InsertData(
                table: "prescriptions",
                columns: new[] { "id", "AppointmentBooking", "AppointmentDoctorId", "AppointmentPatientId" },
                values: new object[,]
                {
                    { 1, null, null, null },
                    { 2, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "appointments",
                columns: new[] { "booking", "doctor_id", "patient_id", "prescription_id" },
                values: new object[,]
                {
                    { new DateTime(2024, 2, 8, 12, 36, 55, 15, DateTimeKind.Utc).AddTicks(2412), 1, 1, null },
                    { new DateTime(2024, 2, 8, 12, 36, 55, 15, DateTimeKind.Utc).AddTicks(2412), 1, 2, null },
                    { new DateTime(2024, 2, 8, 13, 36, 55, 15, DateTimeKind.Utc).AddTicks(2412), 3, 1, null },
                    { new DateTime(2024, 2, 8, 14, 6, 55, 15, DateTimeKind.Utc).AddTicks(2412), 1, 2, null },
                    { new DateTime(2024, 2, 8, 14, 36, 55, 15, DateTimeKind.Utc).AddTicks(2412), 2, 1, null },
                    { new DateTime(2024, 2, 8, 15, 6, 55, 15, DateTimeKind.Utc).AddTicks(2412), 3, 3, null },
                    { new DateTime(2024, 2, 8, 15, 36, 55, 15, DateTimeKind.Utc).AddTicks(2412), 2, 2, null },
                    { new DateTime(2024, 2, 8, 16, 6, 55, 15, DateTimeKind.Utc).AddTicks(2412), 2, 3, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PrescriptionMedicines_PrescriptionsId",
                table: "PrescriptionMedicines",
                column: "PrescriptionsId");

            migrationBuilder.CreateIndex(
                name: "IX_appointments_doctor_id",
                table: "appointments",
                column: "doctor_id");

            migrationBuilder.CreateIndex(
                name: "IX_appointments_patient_id",
                table: "appointments",
                column: "patient_id");

            migrationBuilder.CreateIndex(
                name: "IX_prescriptions_AppointmentBooking_AppointmentPatientId_Appoi~",
                table: "prescriptions",
                columns: new[] { "AppointmentBooking", "AppointmentPatientId", "AppointmentDoctorId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PrescriptionMedicines");

            migrationBuilder.DropTable(
                name: "medicines");

            migrationBuilder.DropTable(
                name: "prescriptions");

            migrationBuilder.DropTable(
                name: "appointments");

            migrationBuilder.DropTable(
                name: "doctors");

            migrationBuilder.DropTable(
                name: "patients");
        }
    }
}
