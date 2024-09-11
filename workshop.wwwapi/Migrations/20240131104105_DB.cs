using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class DB : Migration
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
                name: "patient",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    full_name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patient", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "appointment",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    booking_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    doctor_id = table.Column<int>(type: "integer", nullable: false),
                    patient_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_appointment", x => x.id);
                    table.ForeignKey(
                        name: "FK_appointment_doctor_doctor_id",
                        column: x => x.doctor_id,
                        principalTable: "doctor",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_appointment_patient_patient_id",
                        column: x => x.patient_id,
                        principalTable: "patient",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "doctor",
                columns: new[] { "id", "full_name" },
                values: new object[,]
                {
                    { 1, "Doctor Doe" },
                    { 2, "Doctor Doe" }
                });

            migrationBuilder.InsertData(
                table: "patient",
                columns: new[] { "id", "full_name" },
                values: new object[,]
                {
                    { 1, "John Doe" },
                    { 2, "Jane Doe" }
                });

            migrationBuilder.InsertData(
                table: "appointment",
                columns: new[] { "id", "booking_date", "doctor_id", "patient_id" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 31, 10, 41, 2, 797, DateTimeKind.Utc).AddTicks(7098), 1, 1 },
                    { 2, new DateTime(2024, 1, 31, 11, 41, 2, 797, DateTimeKind.Utc).AddTicks(7102), 2, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_appointment_doctor_id",
                table: "appointment",
                column: "doctor_id");

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
