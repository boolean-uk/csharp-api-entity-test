using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class mig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "doctors",
                columns: table => new
                {
                    doctor_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    doctor_name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_doctors", x => x.doctor_id);
                });

            migrationBuilder.CreateTable(
                name: "patients",
                columns: table => new
                {
                    patient_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    patient_name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patients", x => x.patient_id);
                });

            migrationBuilder.CreateTable(
                name: "appointments",
                columns: table => new
                {
                    appointment_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    appointment_type = table.Column<string>(type: "text", nullable: false),
                    booking_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    fk_doctor_id = table.Column<int>(type: "integer", nullable: false),
                    fk_patient_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_appointments", x => x.appointment_id);
                    table.ForeignKey(
                        name: "FK_appointments_doctors_fk_doctor_id",
                        column: x => x.fk_doctor_id,
                        principalTable: "doctors",
                        principalColumn: "doctor_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_appointments_patients_fk_patient_id",
                        column: x => x.fk_patient_id,
                        principalTable: "patients",
                        principalColumn: "patient_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "doctors",
                columns: new[] { "doctor_id", "doctor_name" },
                values: new object[,]
                {
                    { 1, "Yumi Yumisen" },
                    { 2, "Milo Milosen" }
                });

            migrationBuilder.InsertData(
                table: "patients",
                columns: new[] { "patient_id", "patient_name" },
                values: new object[,]
                {
                    { 1, "Sebastian Hanssen" },
                    { 2, "Anna Lorentzen" }
                });

            migrationBuilder.InsertData(
                table: "appointments",
                columns: new[] { "appointment_id", "booking_time", "appointment_type", "fk_doctor_id", "fk_patient_id" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 2, 5, 14, 0, 0, 0, DateTimeKind.Utc), "Online", 1, 1 },
                    { 2, new DateTime(2024, 2, 5, 15, 0, 0, 0, DateTimeKind.Utc), "Online", 1, 2 },
                    { 3, new DateTime(2024, 2, 6, 14, 0, 0, 0, DateTimeKind.Utc), "Online", 2, 1 },
                    { 4, new DateTime(2024, 2, 6, 15, 0, 0, 0, DateTimeKind.Utc), "Online", 2, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_appointments_fk_doctor_id",
                table: "appointments",
                column: "fk_doctor_id");

            migrationBuilder.CreateIndex(
                name: "IX_appointments_fk_patient_id",
                table: "appointments",
                column: "fk_patient_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "appointments");

            migrationBuilder.DropTable(
                name: "doctors");

            migrationBuilder.DropTable(
                name: "patients");
        }
    }
}
