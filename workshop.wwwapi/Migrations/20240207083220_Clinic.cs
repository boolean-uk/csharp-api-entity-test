using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class Clinic : Migration
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
                    doctor_id = table.Column<int>(type: "integer", nullable: false),
                    patient_id = table.Column<int>(type: "integer", nullable: false),
                    appointment_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_appointment", x => new { x.doctor_id, x.patient_id });
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
                    { 1, "Audrey Winfrey" },
                    { 2, "Audrey Obama" },
                    { 3, "Charles Middleton" },
                    { 4, "Kate Hendrix" },
                    { 5, "Audrey Hendrix" },
                    { 6, "Charles Middleton" },
                    { 7, "Mick Windsor" },
                    { 8, "Barack Hendrix" },
                    { 9, "Kate Windsor" },
                    { 10, "Audrey Trump" }
                });

            migrationBuilder.InsertData(
                table: "patient",
                columns: new[] { "id", "full_name" },
                values: new object[,]
                {
                    { 1, "Kate Winslet" },
                    { 2, "Audrey Presley" },
                    { 3, "Audrey Winslet" },
                    { 4, "Charles Hendrix" },
                    { 5, "Oprah Presley" },
                    { 6, "Barack Winslet" },
                    { 7, "Mick Middleton" },
                    { 8, "Kate Presley" },
                    { 9, "Jimi Presley" },
                    { 10, "Charles Presley" }
                });

            migrationBuilder.InsertData(
                table: "appointment",
                columns: new[] { "doctor_id", "patient_id", "appointment_time" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 2, 7, 8, 32, 19, 792, DateTimeKind.Utc).AddTicks(9367) },
                    { 2, 2, new DateTime(2024, 2, 7, 8, 32, 19, 792, DateTimeKind.Utc).AddTicks(9369) },
                    { 3, 3, new DateTime(2024, 2, 7, 8, 32, 19, 792, DateTimeKind.Utc).AddTicks(9370) },
                    { 4, 4, new DateTime(2024, 2, 7, 8, 32, 19, 792, DateTimeKind.Utc).AddTicks(9370) },
                    { 5, 5, new DateTime(2024, 2, 7, 8, 32, 19, 792, DateTimeKind.Utc).AddTicks(9370) },
                    { 6, 6, new DateTime(2024, 2, 7, 8, 32, 19, 792, DateTimeKind.Utc).AddTicks(9371) },
                    { 7, 7, new DateTime(2024, 2, 7, 8, 32, 19, 792, DateTimeKind.Utc).AddTicks(9372) },
                    { 8, 8, new DateTime(2024, 2, 7, 8, 32, 19, 792, DateTimeKind.Utc).AddTicks(9372) },
                    { 9, 9, new DateTime(2024, 2, 7, 8, 32, 19, 792, DateTimeKind.Utc).AddTicks(9372) },
                    { 10, 10, new DateTime(2024, 2, 7, 8, 32, 19, 792, DateTimeKind.Utc).AddTicks(9373) }
                });

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
