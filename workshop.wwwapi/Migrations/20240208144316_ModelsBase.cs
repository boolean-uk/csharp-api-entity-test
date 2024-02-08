using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class ModelsBase : Migration
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
                    { 1, "Jimi Winslet" },
                    { 2, "Kate Winslet" },
                    { 3, "Charles Middleton" },
                    { 4, "Donald Presley" },
                    { 5, "Elvis Middleton" }
                });

            migrationBuilder.InsertData(
                table: "patients",
                columns: new[] { "id", "full_name" },
                values: new object[,]
                {
                    { 1, "Barack Windsor" },
                    { 2, "Kate Windsor" },
                    { 3, "Jimi Jagger" },
                    { 4, "Jimi Presley" },
                    { 5, "Barack Middleton" },
                    { 6, "Kate Obama" },
                    { 7, "Kate Presley" },
                    { 8, "Donald Hepburn" },
                    { 9, "Kate Obama" },
                    { 10, "Charles Winfrey" }
                });

            migrationBuilder.InsertData(
                table: "appointments",
                columns: new[] { "booking", "doctor_id", "patient_id" },
                values: new object[,]
                {
                    { new DateTime(2024, 2, 11, 14, 43, 15, 860, DateTimeKind.Utc).AddTicks(5945), 5, 3 },
                    { new DateTime(2024, 2, 12, 14, 43, 15, 860, DateTimeKind.Utc).AddTicks(5961), 4, 10 },
                    { new DateTime(2024, 2, 17, 14, 43, 15, 860, DateTimeKind.Utc).AddTicks(5957), 2, 6 },
                    { new DateTime(2024, 2, 20, 14, 43, 15, 860, DateTimeKind.Utc).AddTicks(5958), 2, 3 },
                    { new DateTime(2024, 2, 24, 14, 43, 15, 860, DateTimeKind.Utc).AddTicks(5959), 2, 3 },
                    { new DateTime(2024, 2, 25, 14, 43, 15, 860, DateTimeKind.Utc).AddTicks(5961), 5, 3 },
                    { new DateTime(2024, 2, 26, 14, 43, 15, 860, DateTimeKind.Utc).AddTicks(5958), 5, 8 },
                    { new DateTime(2024, 3, 3, 14, 43, 15, 860, DateTimeKind.Utc).AddTicks(5957), 3, 7 },
                    { new DateTime(2024, 3, 4, 14, 43, 15, 860, DateTimeKind.Utc).AddTicks(5960), 3, 9 },
                    { new DateTime(2024, 3, 8, 14, 43, 15, 860, DateTimeKind.Utc).AddTicks(5962), 2, 9 }
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
