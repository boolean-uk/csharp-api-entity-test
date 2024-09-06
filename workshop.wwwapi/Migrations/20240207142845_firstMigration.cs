using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class firstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "doctor",
                columns: table => new
                {
                    doctor_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    full_name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_doctor", x => x.doctor_id);
                });

            migrationBuilder.CreateTable(
                name: "patient",
                columns: table => new
                {
                    patient_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    full_name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patient", x => x.patient_id);
                });

            migrationBuilder.CreateTable(
                name: "appointment",
                columns: table => new
                {
                    doctor_id = table.Column<int>(type: "integer", nullable: false),
                    patient_id = table.Column<int>(type: "integer", nullable: false),
                    booking_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    appointmenttype = table.Column<int>(name: "appointment type", type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_appointment", x => new { x.doctor_id, x.patient_id });
                    table.ForeignKey(
                        name: "FK_appointment_doctor_doctor_id",
                        column: x => x.doctor_id,
                        principalTable: "doctor",
                        principalColumn: "doctor_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_appointment_patient_patient_id",
                        column: x => x.patient_id,
                        principalTable: "patient",
                        principalColumn: "patient_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "doctor",
                columns: new[] { "doctor_id", "full_name" },
                values: new object[,]
                {
                    { 1, "Dr House" },
                    { 2, "Dr Who" }
                });

            migrationBuilder.InsertData(
                table: "patient",
                columns: new[] { "patient_id", "full_name" },
                values: new object[,]
                {
                    { 1, "Ola Nordmann" },
                    { 2, "Kari Nordmann" },
                    { 3, "Mikolaj Baran" }
                });

            migrationBuilder.InsertData(
                table: "appointment",
                columns: new[] { "doctor_id", "patient_id", "booking_date", "appointment type" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 2, 7, 14, 28, 44, 801, DateTimeKind.Utc).AddTicks(8146), 1 },
                    { 1, 2, new DateTime(2024, 2, 7, 14, 28, 44, 801, DateTimeKind.Utc).AddTicks(8148), 1 },
                    { 2, 1, new DateTime(2024, 2, 7, 14, 28, 44, 801, DateTimeKind.Utc).AddTicks(8148), 0 },
                    { 2, 2, new DateTime(2024, 2, 7, 14, 28, 44, 801, DateTimeKind.Utc).AddTicks(8149), 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_appointment_patient_id",
                table: "appointment",
                column: "patient_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "appointment");

            migrationBuilder.DropTable(
                name: "doctor");

            migrationBuilder.DropTable(
                name: "patient");
        }
    }
}
