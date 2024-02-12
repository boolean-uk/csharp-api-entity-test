using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class Appointmentcs : Migration
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
                    full_name = table.Column<string>(type: "text", nullable: false)
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
                    full_name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patients", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "appointments",
                columns: table => new
                {
                    doctor_id = table.Column<int>(type: "integer", nullable: false),
                    patient_id = table.Column<int>(type: "integer", nullable: false),
                    booking = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_appointments", x => new { x.booking, x.doctor_id, x.patient_id });
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
                columns: new[] { "id", "full_name" },
                values: new object[,]
                {
                    { 1, "Mick Trump" },
                    { 2, "Mick Winslet" },
                    { 3, "Barack Hepburn" },
                    { 4, "Oprah Winslet" },
                    { 5, "Jimi Winfrey" }
                });

            migrationBuilder.InsertData(
                table: "patients",
                columns: new[] { "id", "full_name" },
                values: new object[,]
                {
                    { 1, "Donald Hepburn" },
                    { 2, "Jimi Windsor" },
                    { 3, "Jimi Hendrix" },
                    { 4, "Audrey Obama" },
                    { 5, "Elvis Hendrix" },
                    { 6, "Kate Hepburn" },
                    { 7, "Charles Presley" },
                    { 8, "Kate Obama" },
                    { 9, "Charles Winslet" },
                    { 10, "Elvis Windsor" }
                });

            migrationBuilder.InsertData(
                table: "appointments",
                columns: new[] { "booking", "doctor_id", "patient_id" },
                values: new object[,]
                {
                    { new DateTime(2024, 2, 14, 9, 14, 31, 437, DateTimeKind.Utc).AddTicks(3692), 5, 2 },
                    { new DateTime(2024, 2, 23, 9, 14, 31, 437, DateTimeKind.Utc).AddTicks(3689), 4, 4 },
                    { new DateTime(2024, 2, 24, 9, 14, 31, 437, DateTimeKind.Utc).AddTicks(3708), 2, 3 },
                    { new DateTime(2024, 2, 26, 9, 14, 31, 437, DateTimeKind.Utc).AddTicks(3701), 4, 9 },
                    { new DateTime(2024, 2, 27, 9, 14, 31, 437, DateTimeKind.Utc).AddTicks(3703), 5, 3 },
                    { new DateTime(2024, 2, 29, 9, 14, 31, 437, DateTimeKind.Utc).AddTicks(3671), 2, 5 },
                    { new DateTime(2024, 3, 1, 9, 14, 31, 437, DateTimeKind.Utc).AddTicks(3693), 2, 7 },
                    { new DateTime(2024, 3, 1, 9, 14, 31, 437, DateTimeKind.Utc).AddTicks(3695), 5, 3 },
                    { new DateTime(2024, 3, 5, 9, 14, 31, 437, DateTimeKind.Utc).AddTicks(3705), 2, 7 },
                    { new DateTime(2024, 3, 6, 9, 14, 31, 437, DateTimeKind.Utc).AddTicks(3699), 2, 9 }
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
