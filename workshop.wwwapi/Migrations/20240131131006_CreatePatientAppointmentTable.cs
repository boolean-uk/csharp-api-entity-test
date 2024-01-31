using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class CreatePatientAppointmentTable : Migration
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
                name: "prescription",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_prescription", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "appointments",
                columns: table => new
                {
                    booking = table.Column<string>(type: "text", nullable: false),
                    doctor_id = table.Column<int>(type: "integer", nullable: false),
                    patient_id = table.Column<int>(type: "integer", nullable: false),
                    prescription_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_appointments", x => new { x.booking, x.patient_id, x.doctor_id, x.prescription_id });
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
                    table.ForeignKey(
                        name: "FK_appointments_prescription_prescription_id",
                        column: x => x.prescription_id,
                        principalTable: "prescription",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "doctors",
                columns: new[] { "id", "full_name" },
                values: new object[,]
                {
                    { 1, "Jane Pettersson" },
                    { 2, "Daniella Hoff" },
                    { 3, "Emelie Hogstedt" }
                });

            migrationBuilder.InsertData(
                table: "patients",
                columns: new[] { "id", "full_name" },
                values: new object[,]
                {
                    { 1, "Klara Andersson" },
                    { 2, "Peter Andersson" },
                    { 3, "Arvid Andersson" }
                });

            migrationBuilder.InsertData(
                table: "prescription",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "Head ache" },
                    { 2, "Stomach" },
                    { 3, "Sking" }
                });

            migrationBuilder.InsertData(
                table: "appointments",
                columns: new[] { "booking", "doctor_id", "patient_id", "prescription_id" },
                values: new object[,]
                {
                    { "Now", 1, 2, 3 },
                    { "Today", 2, 1, 1 },
                    { "Tomorrow", 3, 3, 2 }
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
                name: "IX_appointments_prescription_id",
                table: "appointments",
                column: "prescription_id");
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

            migrationBuilder.DropTable(
                name: "prescription");
        }
    }
}
