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
                name: "appointments",
                columns: table => new
                {
                    doctorId = table.Column<int>(type: "integer", nullable: false),
                    patientId = table.Column<int>(type: "integer", nullable: false),
                    id = table.Column<int>(type: "integer", nullable: false),
                    booking = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_appointments", x => new { x.doctorId, x.patientId });
                });

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

            migrationBuilder.InsertData(
                table: "appointments",
                columns: new[] { "doctorId", "patientId", "booking", "id" },
                values: new object[,]
                {
                    { 2, 1, new DateTime(2025, 5, 12, 11, 53, 26, 428, DateTimeKind.Utc).AddTicks(7955), 1 },
                    { 2, 2, new DateTime(2024, 10, 24, 8, 2, 51, 428, DateTimeKind.Utc).AddTicks(8084), 2 }
                });

            migrationBuilder.InsertData(
                table: "doctors",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "Oprah Jagger" },
                    { 2, "Mick Winslet" }
                });

            migrationBuilder.InsertData(
                table: "patients",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "Jimi Trump" },
                    { 2, "Donald Windsor" }
                });
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
