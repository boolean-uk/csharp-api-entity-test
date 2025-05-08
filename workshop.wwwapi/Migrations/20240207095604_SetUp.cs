using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class SetUp : Migration
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
                name: "medicines",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medicines", x => x.id);
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
                name: "prescriptions",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_prescriptions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "appointment",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    booking = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    fk_doctor_id = table.Column<int>(type: "integer", nullable: false),
                    fk_patient_id = table.Column<int>(type: "integer", nullable: false),
                    fk_prescription_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_appointment", x => x.id);
                    table.ForeignKey(
                        name: "FK_appointment_doctor_fk_doctor_id",
                        column: x => x.fk_doctor_id,
                        principalTable: "doctor",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_appointment_patient_fk_patient_id",
                        column: x => x.fk_patient_id,
                        principalTable: "patient",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_appointment_prescriptions_fk_prescription_id",
                        column: x => x.fk_prescription_id,
                        principalTable: "prescriptions",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "medicine_prescriptions",
                columns: table => new
                {
                    ppk_medicine_Id = table.Column<int>(type: "integer", nullable: false),
                    ppk_prescription_id = table.Column<int>(type: "integer", nullable: false),
                    quantity = table.Column<int>(type: "integer", nullable: false),
                    instructions = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medicine_prescriptions", x => new { x.ppk_medicine_Id, x.ppk_prescription_id });
                    table.ForeignKey(
                        name: "FK_medicine_prescriptions_medicines_ppk_medicine_Id",
                        column: x => x.ppk_medicine_Id,
                        principalTable: "medicines",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_medicine_prescriptions_prescriptions_ppk_prescription_id",
                        column: x => x.ppk_prescription_id,
                        principalTable: "prescriptions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "doctor",
                columns: new[] { "id", "full_name" },
                values: new object[] { 1, "Bob Builder" });

            migrationBuilder.InsertData(
                table: "medicines",
                columns: new[] { "id", "name" },
                values: new object[] { 1, "Weed" });

            migrationBuilder.InsertData(
                table: "patient",
                columns: new[] { "id", "full_name" },
                values: new object[,]
                {
                    { 1, "Sick Guy" },
                    { 2, "Local Junkie" }
                });

            migrationBuilder.InsertData(
                table: "prescriptions",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "painrelief for local junkie" },
                    { 2, "painrelief for local junkie" }
                });

            migrationBuilder.InsertData(
                table: "appointment",
                columns: new[] { "id", "booking", "fk_doctor_id", "fk_patient_id", "fk_prescription_id" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 7, 14, 12, 45, 0, 0, DateTimeKind.Utc), 1, 1, null },
                    { 2, new DateTime(2024, 4, 21, 9, 5, 0, 0, DateTimeKind.Utc), 1, 2, 1 },
                    { 3, new DateTime(2024, 3, 15, 8, 30, 0, 0, DateTimeKind.Utc), 1, 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "medicine_prescriptions",
                columns: new[] { "ppk_medicine_Id", "ppk_prescription_id", "instructions", "quantity" },
                values: new object[,]
                {
                    { 1, 1, "This is all you get for this month!", 1 },
                    { 1, 2, "Try not to smoke it all in onw day!", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_appointment_fk_doctor_id",
                table: "appointment",
                column: "fk_doctor_id");

            migrationBuilder.CreateIndex(
                name: "IX_appointment_fk_patient_id",
                table: "appointment",
                column: "fk_patient_id");

            migrationBuilder.CreateIndex(
                name: "IX_appointment_fk_prescription_id",
                table: "appointment",
                column: "fk_prescription_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_medicine_prescriptions_ppk_prescription_id",
                table: "medicine_prescriptions",
                column: "ppk_prescription_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "appointment");

            migrationBuilder.DropTable(
                name: "medicine_prescriptions");

            migrationBuilder.DropTable(
                name: "doctor");

            migrationBuilder.DropTable(
                name: "patient");

            migrationBuilder.DropTable(
                name: "medicines");

            migrationBuilder.DropTable(
                name: "prescriptions");
        }
    }
}
