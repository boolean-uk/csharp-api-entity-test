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
                name: "MedPrescription",
                columns: table => new
                {
                    med_id = table.Column<int>(type: "integer", nullable: false),
                    prescription_id = table.Column<int>(type: "integer", nullable: false),
                    amount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedPrescription", x => new { x.med_id, x.prescription_id });
                });

            migrationBuilder.CreateTable(
                name: "Medicines",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    medname = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicines", x => x.id);
                });

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
                name: "prescription",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    doctor_id = table.Column<int>(type: "integer", nullable: false),
                    patient_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_prescription", x => x.id);
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
                table: "MedPrescription",
                columns: new[] { "med_id", "prescription_id", "amount" },
                values: new object[,]
                {
                    { 1, 2, 4 },
                    { 1, 3, 4 },
                    { 1, 4, 7 },
                    { 2, 1, 5 },
                    { 2, 5, 1 }
                });

            migrationBuilder.InsertData(
                table: "Medicines",
                columns: new[] { "id", "medname" },
                values: new object[,]
                {
                    { 1, "Paracetamol" },
                    { 2, "Zyrtec" },
                    { 3, "Hyrimoz" }
                });

            migrationBuilder.InsertData(
                table: "doctor",
                columns: new[] { "id", "full_name" },
                values: new object[,]
                {
                    { 1, "Elvis Winfrey" },
                    { 2, "Kate Windsor" },
                    { 3, "Kate Middleton" },
                    { 4, "Mick Middleton" },
                    { 5, "Oprah Winfrey" },
                    { 6, "Elvis Hepburn" },
                    { 7, "Donald Jagger" },
                    { 8, "Charles Windsor" },
                    { 9, "Jimi Hendrix" },
                    { 10, "Elvis Jagger" }
                });

            migrationBuilder.InsertData(
                table: "patient",
                columns: new[] { "id", "full_name" },
                values: new object[,]
                {
                    { 1, "Jimi Hepburn" },
                    { 2, "Charles Trump" },
                    { 3, "Barack Hendrix" },
                    { 4, "Mick Hepburn" },
                    { 5, "Charles Trump" },
                    { 6, "Audrey Obama" },
                    { 7, "Elvis Middleton" },
                    { 8, "Mick Hendrix" },
                    { 9, "Donald Winfrey" },
                    { 10, "Oprah Obama" }
                });

            migrationBuilder.InsertData(
                table: "prescription",
                columns: new[] { "id", "doctor_id", "patient_id" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 },
                    { 3, 3, 3 },
                    { 4, 4, 4 },
                    { 5, 5, 5 }
                });

            migrationBuilder.InsertData(
                table: "appointment",
                columns: new[] { "doctor_id", "patient_id", "appointment_time" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 2, 7, 13, 56, 59, 953, DateTimeKind.Utc).AddTicks(3690) },
                    { 2, 2, new DateTime(2024, 2, 7, 13, 56, 59, 953, DateTimeKind.Utc).AddTicks(3692) },
                    { 3, 3, new DateTime(2024, 2, 7, 13, 56, 59, 953, DateTimeKind.Utc).AddTicks(3693) },
                    { 4, 4, new DateTime(2024, 2, 7, 13, 56, 59, 953, DateTimeKind.Utc).AddTicks(3693) },
                    { 5, 5, new DateTime(2024, 2, 7, 13, 56, 59, 953, DateTimeKind.Utc).AddTicks(3694) },
                    { 6, 6, new DateTime(2024, 2, 7, 13, 56, 59, 953, DateTimeKind.Utc).AddTicks(3695) },
                    { 7, 7, new DateTime(2024, 2, 7, 13, 56, 59, 953, DateTimeKind.Utc).AddTicks(3695) },
                    { 8, 8, new DateTime(2024, 2, 7, 13, 56, 59, 953, DateTimeKind.Utc).AddTicks(3695) },
                    { 9, 9, new DateTime(2024, 2, 7, 13, 56, 59, 953, DateTimeKind.Utc).AddTicks(3696) },
                    { 10, 10, new DateTime(2024, 2, 7, 13, 56, 59, 953, DateTimeKind.Utc).AddTicks(3696) }
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
                name: "MedPrescription");

            migrationBuilder.DropTable(
                name: "Medicines");

            migrationBuilder.DropTable(
                name: "appointment");

            migrationBuilder.DropTable(
                name: "prescription");

            migrationBuilder.DropTable(
                name: "doctor");

            migrationBuilder.DropTable(
                name: "patient");
        }
    }
}
