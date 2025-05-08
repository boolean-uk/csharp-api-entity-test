using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class database_extended : Migration
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
                    full_name = table.Column<string>(type: "character varying(123)", maxLength: 123, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_doctors", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "medicine",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medicine", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "patients",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    full_name = table.Column<string>(type: "character varying(123)", maxLength: 123, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patients", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "appointments",
                columns: table => new
                {
                    appointment_id = table.Column<int>(type: "integer", nullable: false),
                    doctor_id = table.Column<int>(type: "integer", nullable: false),
                    patient_id = table.Column<int>(type: "integer", nullable: false),
                    booking_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_appointments", x => new { x.appointment_id, x.doctor_id, x.patient_id });
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
                name: "prescription",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    doctor_id = table.Column<int>(type: "integer", nullable: false),
                    patient_id = table.Column<int>(type: "integer", nullable: false),
                    appointment_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_prescription", x => x.id);
                    table.ForeignKey(
                        name: "FK_prescription_appointments_appointment_id_doctor_id_patient_~",
                        columns: x => new { x.appointment_id, x.doctor_id, x.patient_id },
                        principalTable: "appointments",
                        principalColumns: new[] { "appointment_id", "doctor_id", "patient_id" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_prescription_doctors_doctor_id",
                        column: x => x.doctor_id,
                        principalTable: "doctors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_prescription_patients_patient_id",
                        column: x => x.patient_id,
                        principalTable: "patients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "prescription_medicine",
                columns: table => new
                {
                    PrescriptionId = table.Column<int>(type: "integer", nullable: false),
                    MedicineId = table.Column<int>(type: "integer", nullable: false),
                    amount = table.Column<int>(type: "integer", nullable: false),
                    instructions = table.Column<string>(type: "character varying(511)", maxLength: 511, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_prescription_medicine", x => new { x.PrescriptionId, x.MedicineId });
                    table.ForeignKey(
                        name: "FK_prescription_medicine_medicine_MedicineId",
                        column: x => x.MedicineId,
                        principalTable: "medicine",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_prescription_medicine_prescription_PrescriptionId",
                        column: x => x.PrescriptionId,
                        principalTable: "prescription",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "doctors",
                columns: new[] { "id", "full_name" },
                values: new object[,]
                {
                    { 1, "Jan Itor" },
                    { 3, "Dr. Acula" }
                });

            migrationBuilder.InsertData(
                table: "medicine",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "Vitalysol" },
                    { 2, "Zypherexa" },
                    { 3, "Pheonixal" }
                });

            migrationBuilder.InsertData(
                table: "patients",
                columns: new[] { "id", "full_name" },
                values: new object[,]
                {
                    { 1, "Jimmy Bob" },
                    { 5, "John Doe" }
                });

            migrationBuilder.InsertData(
                table: "appointments",
                columns: new[] { "doctor_id", "appointment_id", "patient_id", "booking_time" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2010, 3, 5, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 1, 2, 1, new DateTime(2012, 3, 5, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 1, 3, 5, new DateTime(2005, 5, 10, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 1, 4, 5, new DateTime(2007, 5, 10, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 1, 5, 5, new DateTime(2009, 5, 10, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 3, 6, 5, new DateTime(1995, 5, 10, 0, 0, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.InsertData(
                table: "prescription",
                columns: new[] { "id", "appointment_id", "doctor_id", "name", "patient_id" },
                values: new object[,]
                {
                    { 1, 2, 1, "Preventative care", 1 },
                    { 2, 6, 3, "Cure Infection", 5 },
                    { 3, 3, 1, "Cure cancer", 5 },
                    { 4, 5, 1, "Cure cancer", 5 }
                });

            migrationBuilder.InsertData(
                table: "prescription_medicine",
                columns: new[] { "MedicineId", "PrescriptionId", "amount", "instructions" },
                values: new object[,]
                {
                    { 1, 1, 42, "One dose each morning for 3 weeks." },
                    { 2, 1, 28, "2 pills each day for 2 weeks." },
                    { 3, 2, 10, "5 pills each day for 2 days." },
                    { 1, 4, 10, "One dose each morning for 10 days." }
                });

            migrationBuilder.CreateIndex(
                name: "IX_appointments_doctor_id",
                table: "appointments",
                column: "doctor_id");

            migrationBuilder.CreateIndex(
                name: "IX_appointments_patient_id",
                table: "appointments",
                column: "patient_id");

            migrationBuilder.CreateIndex(
                name: "IX_prescription_appointment_id_doctor_id_patient_id",
                table: "prescription",
                columns: new[] { "appointment_id", "doctor_id", "patient_id" });

            migrationBuilder.CreateIndex(
                name: "IX_prescription_doctor_id",
                table: "prescription",
                column: "doctor_id");

            migrationBuilder.CreateIndex(
                name: "IX_prescription_patient_id",
                table: "prescription",
                column: "patient_id");

            migrationBuilder.CreateIndex(
                name: "IX_prescription_medicine_MedicineId",
                table: "prescription_medicine",
                column: "MedicineId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "prescription_medicine");

            migrationBuilder.DropTable(
                name: "medicine");

            migrationBuilder.DropTable(
                name: "prescription");

            migrationBuilder.DropTable(
                name: "appointments");

            migrationBuilder.DropTable(
                name: "doctors");

            migrationBuilder.DropTable(
                name: "patients");
        }
    }
}
