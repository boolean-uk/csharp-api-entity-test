using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class Hospital : Migration
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
                    fullname = table.Column<string>(type: "text", nullable: false)
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
                    fullname = table.Column<string>(type: "text", nullable: false)
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
                    table.PrimaryKey("PK_appointments", x => new { x.patient_id, x.doctor_id, x.booking });
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
                columns: new[] { "id", "fullname" },
                values: new object[,]
                {
                    { 1, "Fae Molenaar" },
                    { 2, "Tobias Bockmann" },
                    { 3, "Josephine Rademaker" },
                    { 4, "Dylan Lusse" }
                });

            migrationBuilder.InsertData(
                table: "patients",
                columns: new[] { "id", "fullname" },
                values: new object[,]
                {
                    { 1, "Dagmar van den Berg" },
                    { 2, "Lieve van den Berg" },
                    { 3, "Daphne Lakmaker" },
                    { 4, "Amber Spoelstra" }
                });

            migrationBuilder.InsertData(
                table: "appointments",
                columns: new[] { "booking", "doctor_id", "patient_id" },
                values: new object[,]
                {
                    { new DateTime(2024, 1, 31, 13, 16, 26, 362, DateTimeKind.Utc).AddTicks(1489), 1, 1 },
                    { new DateTime(2024, 1, 31, 13, 16, 26, 362, DateTimeKind.Utc).AddTicks(1560), 2, 1 },
                    { new DateTime(2024, 1, 31, 13, 16, 26, 362, DateTimeKind.Utc).AddTicks(1583), 4, 1 },
                    { new DateTime(2024, 1, 31, 13, 16, 26, 362, DateTimeKind.Utc).AddTicks(1564), 3, 2 },
                    { new DateTime(2024, 1, 31, 13, 16, 26, 362, DateTimeKind.Utc).AddTicks(1586), 1, 3 },
                    { new DateTime(2024, 1, 31, 13, 16, 26, 362, DateTimeKind.Utc).AddTicks(1598), 2, 3 },
                    { new DateTime(2024, 1, 31, 13, 16, 26, 362, DateTimeKind.Utc).AddTicks(1594), 2, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_appointments_doctor_id",
                table: "appointments",
                column: "doctor_id");
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
