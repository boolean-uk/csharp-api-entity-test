using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class ReAddingAllTablesCoreAndExtensions : Migration
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
                name: "medicines",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medicines", x => x.id);
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
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    bookings = table.Column<string>(type: "text", nullable: false),
                    appointment_type = table.Column<int>(type: "integer", nullable: false),
                    doctor_id = table.Column<int>(type: "integer", nullable: false),
                    patient_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_appointments", x => x.id);
                    table.ForeignKey(
                        name: "FK_appointments_doctors_doctor_id",
                        column: x => x.doctor_id,
                        principalTable: "doctors",
                        principalColumn: "doctor_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_appointments_patients_patient_id",
                        column: x => x.patient_id,
                        principalTable: "patients",
                        principalColumn: "patient_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "prescriptions",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    notes = table.Column<string>(type: "text", nullable: true),
                    appointment_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_prescriptions", x => x.id);
                    table.ForeignKey(
                        name: "FK_prescriptions_appointments_appointment_id",
                        column: x => x.appointment_id,
                        principalTable: "appointments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "prescription_medicine",
                columns: table => new
                {
                    prescription_id = table.Column<int>(type: "integer", nullable: false),
                    medicine_id = table.Column<int>(type: "integer", nullable: false),
                    quantiry = table.Column<int>(type: "integer", nullable: true),
                    notes = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_prescription_medicine", x => new { x.prescription_id, x.medicine_id });
                    table.ForeignKey(
                        name: "FK_prescription_medicine_medicines_medicine_id",
                        column: x => x.medicine_id,
                        principalTable: "medicines",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_prescription_medicine_prescriptions_prescription_id",
                        column: x => x.prescription_id,
                        principalTable: "prescriptions",
                        principalColumn: "id",
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
                table: "medicines",
                columns: new[] { "id", "description", "name" },
                values: new object[,]
                {
                    { 1, "Description 1", "Medicine 1" },
                    { 2, "Description 2", "Medicine 2" }
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
                columns: new[] { "id", "bookings", "doctor_id", "patient_id", "appointment_type" },
                values: new object[,]
                {
                    { 1, "2024-02-09", 3, 1, 1 },
                    { 2, "2024-02-09", 1, 4, 0 },
                    { 3, "2024-02-09", 3, 2, 1 },
                    { 4, "2024-02-09", 2, 6, 1 },
                    { 5, "2024-02-09", 3, 3, 1 },
                    { 6, "2024-02-09", 3, 5, 0 },
                    { 7, "2024-02-09", 2, 7, 0 },
                    { 8, "2024-02-09", 1, 8, 1 }
                });

            migrationBuilder.InsertData(
                table: "prescriptions",
                columns: new[] { "id", "appointment_id", "notes" },
                values: new object[,]
                {
                    { 1, 1, null },
                    { 2, 2, null }
                });

            migrationBuilder.InsertData(
                table: "prescription_medicine",
                columns: new[] { "medicine_id", "prescription_id", "notes", "quantiry" },
                values: new object[,]
                {
                    { 1, 1, "Take with food", 2 },
                    { 2, 1, "Before bedtime", 1 },
                    { 2, 2, "Twice a day", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_appointments_doctor_id",
                table: "appointments",
                column: "doctor_id");

            migrationBuilder.CreateIndex(
                name: "IX_appointments_patient_id",
                table: "appointments",
                column: "patient_id");

            migrationBuilder.CreateIndex(
                name: "IX_prescription_medicine_medicine_id",
                table: "prescription_medicine",
                column: "medicine_id");

            migrationBuilder.CreateIndex(
                name: "IX_prescriptions_appointment_id",
                table: "prescriptions",
                column: "appointment_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "prescription_medicine");

            migrationBuilder.DropTable(
                name: "medicines");

            migrationBuilder.DropTable(
                name: "prescriptions");

            migrationBuilder.DropTable(
                name: "appointments");

            migrationBuilder.DropTable(
                name: "doctors");

            migrationBuilder.DropTable(
                name: "patients");
        }
    }
}
