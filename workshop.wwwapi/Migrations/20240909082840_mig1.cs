using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Medicines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    Instructions = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "doctors",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    full_Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_doctors", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "patients",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    full_Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patients", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "appointments",
                columns: table => new
                {
                    appointment_Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    booking_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DoctorId = table.Column<int>(type: "integer", nullable: false),
                    PatientId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_appointments", x => x.appointment_Id);
                    table.ForeignKey(
                        name: "FK_appointments_doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "doctors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_appointments_patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "patients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Perscriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AppointmentId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perscriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Perscriptions_appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "appointments",
                        principalColumn: "appointment_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PrescriptionMedicines",
                columns: table => new
                {
                    MedicinesId = table.Column<int>(type: "integer", nullable: false),
                    PerscriptionId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrescriptionMedicines", x => new { x.MedicinesId, x.PerscriptionId });
                    table.ForeignKey(
                        name: "FK_PrescriptionMedicines_Medicines_MedicinesId",
                        column: x => x.MedicinesId,
                        principalTable: "Medicines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PrescriptionMedicines_Perscriptions_PerscriptionId",
                        column: x => x.PerscriptionId,
                        principalTable: "Perscriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Medicines",
                columns: new[] { "Id", "Instructions", "Name", "Quantity" },
                values: new object[,]
                {
                    { 1, "After every meal", "Paracetamol", 4 },
                    { 2, "Before every meal", "Ibuprofen", 2 }
                });

            migrationBuilder.InsertData(
                table: "doctors",
                columns: new[] { "id", "full_Name" },
                values: new object[,]
                {
                    { 1, "Dr. John Doe" },
                    { 2, "Dr. Jane Doe" }
                });

            migrationBuilder.InsertData(
                table: "patients",
                columns: new[] { "id", "full_Name" },
                values: new object[,]
                {
                    { 1, "Jane Doe" },
                    { 2, "John Doe" }
                });

            migrationBuilder.InsertData(
                table: "appointments",
                columns: new[] { "appointment_Id", "booking_time", "DoctorId", "PatientId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 9, 8, 28, 39, 629, DateTimeKind.Utc).AddTicks(1837), 1, 1 },
                    { 2, new DateTime(2024, 9, 9, 8, 28, 39, 629, DateTimeKind.Utc).AddTicks(1842), 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "Perscriptions",
                columns: new[] { "Id", "AppointmentId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "PrescriptionMedicines",
                columns: new[] { "MedicinesId", "PerscriptionId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Perscriptions_AppointmentId",
                table: "Perscriptions",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_PrescriptionMedicines_PerscriptionId",
                table: "PrescriptionMedicines",
                column: "PerscriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_appointments_DoctorId",
                table: "appointments",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_appointments_PatientId",
                table: "appointments",
                column: "PatientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PrescriptionMedicines");

            migrationBuilder.DropTable(
                name: "Medicines");

            migrationBuilder.DropTable(
                name: "Perscriptions");

            migrationBuilder.DropTable(
                name: "appointments");

            migrationBuilder.DropTable(
                name: "doctors");

            migrationBuilder.DropTable(
                name: "patients");
        }
    }
}
