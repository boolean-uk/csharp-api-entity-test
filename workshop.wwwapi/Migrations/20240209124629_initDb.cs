using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class initDb : Migration
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
                    fullname = table.Column<string>(type: "text", nullable: false)
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
                    fullname = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patient", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "appointment",
                columns: table => new
                {
                    booking = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    doctorid = table.Column<int>(type: "integer", nullable: false),
                    patientid = table.Column<int>(type: "integer", nullable: false),
                    appointmenttype = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_appointment", x => new { x.doctorid, x.patientid, x.booking });
                    table.ForeignKey(
                        name: "FK_appointment_doctor_doctorid",
                        column: x => x.doctorid,
                        principalTable: "doctor",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_appointment_patient_patientid",
                        column: x => x.patientid,
                        principalTable: "patient",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "doctor",
                columns: new[] { "id", "fullname" },
                values: new object[,]
                {
                    { 1, "Ulf Liljenberg" },
                    { 2, "Phillip McGraw" },
                    { 3, "Ken Jeong" }
                });

            migrationBuilder.InsertData(
                table: "patient",
                columns: new[] { "id", "fullname" },
                values: new object[,]
                {
                    { 1, "Elias Soprani" },
                    { 2, "Olga Alm" },
                    { 3, "Oskar Damkilde" },
                    { 4, "Gabriel Letell" },
                    { 5, "Samuel Vacha" },
                    { 6, "Theodor Johansson" }
                });

            migrationBuilder.InsertData(
                table: "appointment",
                columns: new[] { "booking", "doctorid", "patientid", "appointmenttype" },
                values: new object[,]
                {
                    { new DateTime(2024, 1, 11, 11, 0, 0, 0, DateTimeKind.Utc), 1, 1, 0 },
                    { new DateTime(2024, 2, 2, 14, 0, 0, 0, DateTimeKind.Utc), 1, 1, 0 },
                    { new DateTime(2024, 5, 29, 13, 0, 0, 0, DateTimeKind.Utc), 1, 3, 0 },
                    { new DateTime(2024, 3, 13, 10, 0, 0, 0, DateTimeKind.Utc), 1, 4, 0 },
                    { new DateTime(2024, 1, 17, 13, 0, 0, 0, DateTimeKind.Utc), 2, 2, 0 },
                    { new DateTime(2024, 2, 16, 9, 0, 0, 0, DateTimeKind.Utc), 2, 5, 0 },
                    { new DateTime(2024, 1, 6, 12, 0, 0, 0, DateTimeKind.Utc), 3, 2, 0 },
                    { new DateTime(2024, 4, 15, 8, 0, 0, 0, DateTimeKind.Utc), 3, 6, 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_appointment_patientid",
                table: "appointment",
                column: "patientid");
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
