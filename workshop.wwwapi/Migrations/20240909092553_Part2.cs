using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class Part2 : Migration
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
                    doctorid = table.Column<int>(type: "integer", nullable: false),
                    patientid = table.Column<int>(type: "integer", nullable: false),
                    booking = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_appointments", x => new { x.patientid, x.doctorid });
                    table.ForeignKey(
                        name: "FK_appointments_doctors_doctorid",
                        column: x => x.doctorid,
                        principalTable: "doctors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_appointments_patients_patientid",
                        column: x => x.patientid,
                        principalTable: "patients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "doctors",
                columns: new[] { "id", "fullname" },
                values: new object[,]
                {
                    { 1, "Dr. Alok Kanojia" },
                    { 2, "Dr. Sigmund Freud" },
                    { 3, "Dr. Carl Jung" },
                    { 4, "Dr. Friedrich Nietzsche" }
                });

            migrationBuilder.InsertData(
                table: "patients",
                columns: new[] { "id", "fullname" },
                values: new object[,]
                {
                    { 1, "Donald Trump" },
                    { 2, "Fredrik Reinfeldt" },
                    { 3, "Astrid Lindgren" },
                    { 4, "Mike Tyson" }
                });

            migrationBuilder.InsertData(
                table: "appointments",
                columns: new[] { "doctorid", "patientid", "booking" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 9, 9, 9, 25, 52, 767, DateTimeKind.Utc).AddTicks(1186) },
                    { 2, 2, new DateTime(2024, 9, 9, 9, 25, 52, 767, DateTimeKind.Utc).AddTicks(1193) },
                    { 3, 3, new DateTime(2024, 9, 9, 9, 25, 52, 767, DateTimeKind.Utc).AddTicks(1194) },
                    { 4, 4, new DateTime(2024, 9, 9, 9, 25, 52, 767, DateTimeKind.Utc).AddTicks(1195) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_appointments_doctorid",
                table: "appointments",
                column: "doctorid");
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
