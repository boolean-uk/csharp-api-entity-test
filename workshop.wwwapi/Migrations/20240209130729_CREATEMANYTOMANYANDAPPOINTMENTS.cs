using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class CREATEMANYTOMANYANDAPPOINTMENTS : Migration
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
                    full_name = table.Column<string>(type: "text", nullable: false)
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
                    notes = table.Column<string>(type: "text", nullable: false)
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
                    full_name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patients", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "appointments",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    doctor_id = table.Column<int>(type: "integer", nullable: false),
                    patient_id = table.Column<int>(type: "integer", nullable: false),
                    appointment_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_appointments", x => x.id);
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
                    name = table.Column<string>(type: "text", nullable: false),
                    appointment_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_prescriptions", x => x.id);
                    table.ForeignKey(
                        name: "FK_prescriptions_appointments_appointment_id",
                        column: x => x.appointment_id,
                        principalTable: "appointments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "medicine_prescriptions",
                columns: table => new
                {
                    medicine_id = table.Column<int>(type: "integer", nullable: false),
                    prescription_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medicine_prescriptions", x => new { x.medicine_id, x.prescription_id });
                    table.ForeignKey(
                        name: "FK_medicine_prescriptions_medicines_medicine_id",
                        column: x => x.medicine_id,
                        principalTable: "medicines",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_medicine_prescriptions_prescriptions_prescription_id",
                        column: x => x.prescription_id,
                        principalTable: "prescriptions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "doctors",
                columns: new[] { "id", "full_name" },
                values: new object[,]
                {
                    { 1, "DR. Olleson" },
                    { 2, "DR. Andersson" },
                    { 3, "DR. Eriksson" },
                    { 4, "DR. Johnnyson" }
                });

            migrationBuilder.InsertData(
                table: "medicines",
                columns: new[] { "id", "name", "notes", "quantity" },
                values: new object[,]
                {
                    { 1, "Medicine1", "note1", 2 },
                    { 2, "Medicine2", "note2", 3 },
                    { 3, "Medicine3", "note3", 1 },
                    { 4, "Medicine4", "note4", 5 },
                    { 5, "Medicine5", "note5", 2 }
                });

            migrationBuilder.InsertData(
                table: "patients",
                columns: new[] { "id", "full_name" },
                values: new object[,]
                {
                    { 1, "Joel Joelsson" },
                    { 2, "Patrik Patriksson" },
                    { 3, "Peter Petersson" },
                    { 4, "Gunnar Gunnarsson" }
                });

            migrationBuilder.InsertData(
                table: "appointments",
                columns: new[] { "id", "appointment_date", "doctor_id", "patient_id" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 2, 9, 13, 7, 28, 957, DateTimeKind.Utc).AddTicks(3842), 1, 1 },
                    { 2, new DateTime(2024, 2, 9, 13, 7, 28, 957, DateTimeKind.Utc).AddTicks(3850), 2, 2 },
                    { 3, new DateTime(2024, 2, 9, 13, 7, 28, 957, DateTimeKind.Utc).AddTicks(3851), 3, 3 },
                    { 4, new DateTime(2024, 2, 9, 13, 7, 28, 957, DateTimeKind.Utc).AddTicks(3852), 4, 4 }
                });

            migrationBuilder.InsertData(
                table: "prescriptions",
                columns: new[] { "id", "appointment_id", "name" },
                values: new object[,]
                {
                    { 1, 1, "Prescription1" },
                    { 2, 2, "Prescription2" },
                    { 3, 3, "Prescription3" }
                });

            migrationBuilder.InsertData(
                table: "medicine_prescriptions",
                columns: new[] { "medicine_id", "prescription_id" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 4, 3 },
                    { 5, 3 }
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
                name: "IX_medicine_prescriptions_prescription_id",
                table: "medicine_prescriptions",
                column: "prescription_id");

            migrationBuilder.CreateIndex(
                name: "IX_prescriptions_appointment_id",
                table: "prescriptions",
                column: "appointment_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "medicine_prescriptions");

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
