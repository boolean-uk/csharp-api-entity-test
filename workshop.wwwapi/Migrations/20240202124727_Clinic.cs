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
                    { 1, "Elvis Obama" },
                    { 2, "Audrey Jagger" },
                    { 3, "Mick Hepburn" },
                    { 4, "Elvis Presley" },
                    { 5, "Elvis Jagger" },
                    { 6, "Charles Presley" },
                    { 7, "Charles Obama" },
                    { 8, "Donald Trump" },
                    { 9, "Jimi Trump" },
                    { 10, "Audrey Trump" }
                });

            migrationBuilder.InsertData(
                table: "patient",
                columns: new[] { "id", "full_name" },
                values: new object[,]
                {
                    { 1, "Elvis Hepburn" },
                    { 2, "Kate Winslet" },
                    { 3, "Kate Jagger" },
                    { 4, "Oprah Hepburn" },
                    { 5, "Oprah Winslet" },
                    { 6, "Kate Hendrix" },
                    { 7, "Elvis Winfrey" },
                    { 8, "Kate Windsor" },
                    { 9, "Kate Hepburn" },
                    { 10, "Kate Obama" }
                });

            migrationBuilder.InsertData(
                table: "appointment",
                columns: new[] { "doctor_id", "patient_id", "appointment_time" },
                values: new object[,]
                {
                    { 1, 7, new DateTime(2024, 2, 2, 12, 47, 25, 805, DateTimeKind.Utc).AddTicks(9658) },
                    { 3, 3, new DateTime(2024, 2, 2, 12, 47, 25, 805, DateTimeKind.Utc).AddTicks(9654) },
                    { 3, 4, new DateTime(2024, 2, 2, 12, 47, 25, 805, DateTimeKind.Utc).AddTicks(9655) },
                    { 3, 5, new DateTime(2024, 2, 2, 12, 47, 25, 805, DateTimeKind.Utc).AddTicks(9657) },
                    { 4, 3, new DateTime(2024, 2, 2, 12, 47, 25, 805, DateTimeKind.Utc).AddTicks(9654) },
                    { 4, 4, new DateTime(2024, 2, 2, 12, 47, 25, 805, DateTimeKind.Utc).AddTicks(9651) },
                    { 4, 7, new DateTime(2024, 2, 2, 12, 47, 25, 805, DateTimeKind.Utc).AddTicks(9655) },
                    { 6, 3, new DateTime(2024, 2, 2, 12, 47, 25, 805, DateTimeKind.Utc).AddTicks(9658) },
                    { 7, 1, new DateTime(2024, 2, 2, 12, 47, 25, 805, DateTimeKind.Utc).AddTicks(9657) },
                    { 7, 6, new DateTime(2024, 2, 2, 12, 47, 25, 805, DateTimeKind.Utc).AddTicks(9656) }
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
