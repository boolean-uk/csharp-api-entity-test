using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "doctors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_doctors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "patients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "appointments",
                columns: table => new
                {
                    Booking = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DoctorId = table.Column<int>(type: "integer", nullable: false),
                    PatientId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_appointments", x => new { x.PatientId, x.DoctorId, x.Booking });
                    table.ForeignKey(
                        name: "FK_appointments_doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_appointments_patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "doctors",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Hannibal", "Lecter" },
                    { 2, "Henry", "Jones Jr." },
                    { 3, "Davy", "Jones" }
                });

            migrationBuilder.InsertData(
                table: "patients",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "John", "Doe" },
                    { 2, "Jane", "Dough" },
                    { 3, "Hughie", "Dodson" }
                });

            migrationBuilder.InsertData(
                table: "appointments",
                columns: new[] { "Booking", "DoctorId", "PatientId" },
                values: new object[,]
                {
                    { new DateTime(2024, 9, 14, 12, 30, 0, 0, DateTimeKind.Utc), 1, 1 },
                    { new DateTime(2024, 9, 14, 14, 30, 0, 0, DateTimeKind.Utc), 2, 1 },
                    { new DateTime(2024, 9, 14, 13, 30, 0, 0, DateTimeKind.Utc), 3, 1 },
                    { new DateTime(2024, 9, 14, 14, 30, 0, 0, DateTimeKind.Utc), 1, 2 },
                    { new DateTime(2024, 9, 14, 12, 30, 0, 0, DateTimeKind.Utc), 2, 2 },
                    { new DateTime(2024, 9, 14, 14, 30, 0, 0, DateTimeKind.Utc), 3, 2 },
                    { new DateTime(2024, 9, 14, 13, 30, 0, 0, DateTimeKind.Utc), 1, 3 },
                    { new DateTime(2024, 9, 14, 13, 30, 0, 0, DateTimeKind.Utc), 2, 3 },
                    { new DateTime(2024, 9, 14, 12, 30, 0, 0, DateTimeKind.Utc), 3, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_appointments_DoctorId",
                table: "appointments",
                column: "DoctorId");
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
