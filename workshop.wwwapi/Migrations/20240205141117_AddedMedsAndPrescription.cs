using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class AddedMedsAndPrescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "doctor",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    full_name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_doctor", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "medicine",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    quantiy = table.Column<int>(type: "integer", nullable: false)
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
                    full_name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patients", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "prescription",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    instructions = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_prescription", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "appointment",
                columns: table => new
                {
                    doctor_id = table.Column<int>(type: "integer", nullable: false),
                    patient_id = table.Column<int>(type: "integer", nullable: false),
                    booking = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_appointment", x => new { x.patient_id, x.doctor_id });
                    table.ForeignKey(
                        name: "FK_appointment_doctor_doctor_id",
                        column: x => x.doctor_id,
                        principalTable: "doctor",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_appointment_patients_patient_id",
                        column: x => x.patient_id,
                        principalTable: "patients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "prescription_medicine",
                columns: table => new
                {
                    MedicineId = table.Column<int>(type: "integer", nullable: false),
                    PrescriptionId = table.Column<int>(type: "integer", nullable: false)
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
                table: "doctor",
                columns: new[] { "id", "full_name" },
                values: new object[,]
                {
                    { 1, "Dr. Schulz" },
                    { 2, "Dr. Mundo" }
                });

            migrationBuilder.InsertData(
                table: "medicine",
                columns: new[] { "id", "name", "quantiy" },
                values: new object[,]
                {
                    { 1, "Acarizax", 90 },
                    { 2, "Ibuprofen", 16 }
                });

            migrationBuilder.InsertData(
                table: "patients",
                columns: new[] { "id", "full_name" },
                values: new object[,]
                {
                    { 1, "A Patient" },
                    { 2, "Dominic Solanke" },
                    { 3, "Phillip Billing" }
                });

            migrationBuilder.InsertData(
                table: "prescription",
                columns: new[] { "id", "instructions" },
                values: new object[,]
                {
                    { 1, "Take one each morning, avoid swallowing for 1 minute and drinking for 5 minutes." },
                    { 2, "Take as many as u like, avoid alcohol while taking these, or dont, I am not liable anyway." }
                });

            migrationBuilder.InsertData(
                table: "appointment",
                columns: new[] { "doctor_id", "patient_id", "booking" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 2, 6, 14, 11, 17, 374, DateTimeKind.Utc).AddTicks(3273) },
                    { 1, 2, new DateTime(2024, 2, 7, 14, 11, 17, 374, DateTimeKind.Utc).AddTicks(3282) },
                    { 2, 3, new DateTime(2024, 2, 8, 14, 11, 17, 374, DateTimeKind.Utc).AddTicks(3283) }
                });

            migrationBuilder.InsertData(
                table: "prescription_medicine",
                columns: new[] { "MedicineId", "PrescriptionId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_appointment_doctor_id",
                table: "appointment",
                column: "doctor_id");

            migrationBuilder.CreateIndex(
                name: "IX_prescription_medicine_MedicineId",
                table: "prescription_medicine",
                column: "MedicineId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "appointment");

            migrationBuilder.DropTable(
                name: "prescription_medicine");

            migrationBuilder.DropTable(
                name: "doctor");

            migrationBuilder.DropTable(
                name: "patients");

            migrationBuilder.DropTable(
                name: "medicine");

            migrationBuilder.DropTable(
                name: "prescription");
        }
    }
}
