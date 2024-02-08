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
                    patient_id = table.Column<int>(type: "integer", nullable: false)
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
                table: "patients",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "Nigel" },
                    { 2, "AJ" },
                    { 3, "Kevin" }
                });

            migrationBuilder.InsertData(
                table: "appointments",
                columns: new[] { "booking", "doctor_id", "patient_id" },
                values: new object[,]
                {
                    { new DateTime(2024, 2, 8, 7, 48, 19, 502, DateTimeKind.Utc).AddTicks(8313), 1, 1 },
                    { new DateTime(2024, 2, 8, 7, 48, 19, 502, DateTimeKind.Utc).AddTicks(8313), 1, 2 },
                    { new DateTime(2024, 2, 8, 8, 48, 19, 502, DateTimeKind.Utc).AddTicks(8313), 3, 1 },
                    { new DateTime(2024, 2, 8, 9, 18, 19, 502, DateTimeKind.Utc).AddTicks(8313), 1, 2 },
                    { new DateTime(2024, 2, 8, 9, 48, 19, 502, DateTimeKind.Utc).AddTicks(8313), 2, 1 },
                    { new DateTime(2024, 2, 8, 10, 18, 19, 502, DateTimeKind.Utc).AddTicks(8313), 3, 3 },
                    { new DateTime(2024, 2, 8, 10, 48, 19, 502, DateTimeKind.Utc).AddTicks(8313), 2, 2 },
                    { new DateTime(2024, 2, 8, 11, 18, 19, 502, DateTimeKind.Utc).AddTicks(8313), 2, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_appointments_doctor_id",
                table: "appointments",
                column: "doctor_id");

            migrationBuilder.CreateIndex(
                name: "IX_appointments_patient_id",
                table: "appointments",
                column: "patient_id");
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
