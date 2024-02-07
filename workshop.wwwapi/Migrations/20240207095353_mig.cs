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
                    full_name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("doctor_id", x => x.doctor_id);
                });

            migrationBuilder.CreateTable(
                name: "patients",
                columns: table => new
                {
                    patient_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    full_name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("patient_id", x => x.patient_id);
                });

            migrationBuilder.CreateTable(
                name: "appointments",
                columns: table => new
                {
                    DoctorId = table.Column<int>(type: "integer", nullable: false),
                    PatientId = table.Column<int>(type: "integer", nullable: false),
                    booking = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_appointments", x => new { x.PatientId, x.DoctorId });
                    table.ForeignKey(
                        name: "fk_appointments_doctors",
                        column: x => x.DoctorId,
                        principalTable: "doctors",
                        principalColumn: "doctor_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_appointments_patients",
                        column: x => x.PatientId,
                        principalTable: "patients",
                        principalColumn: "patient_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "doctors",
                columns: new[] { "doctor_id", "full_name" },
                values: new object[,]
                {
                    { 1, "Felix Lee" },
                    { 2, "Hyunjin" }
                });

            migrationBuilder.InsertData(
                table: "patients",
                columns: new[] { "patient_id", "full_name" },
                values: new object[,]
                {
                    { 1, "Jeon Jungkook" },
                    { 2, "Kim Taehyung" }
                });

            migrationBuilder.InsertData(
                table: "appointments",
                columns: new[] { "DoctorId", "PatientId", "booking" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 3, 7, 14, 0, 0, 0, DateTimeKind.Utc) },
                    { 2, 2, new DateTime(2024, 4, 8, 15, 0, 0, 0, DateTimeKind.Utc) }
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
