using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class CreateAllTables : Migration
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
                    doctor_full_name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_doctors", x => x.doctor_id);
                });

            migrationBuilder.CreateTable(
                name: "patients",
                columns: table => new
                {
                    patient_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    patient_full_name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patients", x => x.patient_id);
                });

            migrationBuilder.CreateTable(
                name: "appointments",
                columns: table => new
                {
                    bookings = table.Column<string>(type: "text", nullable: false),
                    DoctorId = table.Column<int>(type: "integer", nullable: false),
                    PatientId = table.Column<int>(type: "integer", nullable: false),
                    id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_appointments", x => new { x.bookings, x.DoctorId, x.PatientId });
                    table.ForeignKey(
                        name: "FK_appointments_doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "doctors",
                        principalColumn: "doctor_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_appointments_patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "patients",
                        principalColumn: "patient_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "doctors",
                columns: new[] { "doctor_id", "doctor_full_name" },
                values: new object[,]
                {
                    { 1, "Doktor Docktorsson" },
                    { 2, "Jöran Jöransson" },
                    { 3, "Filip Filipsson" }
                });

            migrationBuilder.InsertData(
                table: "patients",
                columns: new[] { "patient_id", "patient_full_name" },
                values: new object[,]
                {
                    { 1, "Johan Johansson" },
                    { 2, "Sven Svensson" },
                    { 3, "Anders Andresson" },
                    { 4, "Erik Eriksson" },
                    { 5, "Emma Eriksson" },
                    { 6, "Knut Knutsson" },
                    { 7, "Bengt Bengtsson" },
                    { 8, "Jesper Jespersson" }
                });

            migrationBuilder.InsertData(
                table: "appointments",
                columns: new[] { "bookings", "DoctorId", "PatientId", "id" },
                values: new object[,]
                {
                    { "2024-01-31", 1, 4, 2 },
                    { "2024-01-31", 1, 8, 8 },
                    { "2024-01-31", 2, 6, 4 },
                    { "2024-01-31", 2, 7, 7 },
                    { "2024-01-31", 3, 1, 1 },
                    { "2024-01-31", 3, 2, 3 },
                    { "2024-01-31", 3, 3, 5 },
                    { "2024-01-31", 3, 5, 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_appointments_DoctorId",
                table: "appointments",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_appointments_PatientId",
                table: "appointments",
                column: "PatientId");
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
