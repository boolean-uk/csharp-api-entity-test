using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class Prescriptions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Medicines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Prescriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AppointmentDoctorId = table.Column<int>(type: "integer", nullable: false),
                    AppointmentPatientId = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescriptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PrescriptionsMedicines",
                columns: table => new
                {
                    PrescriptionId = table.Column<int>(type: "integer", nullable: false),
                    MedicineId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrescriptionsMedicines", x => new { x.PrescriptionId, x.MedicineId });
                    table.ForeignKey(
                        name: "FK_PrescriptionsMedicines_Medicines_MedicineId",
                        column: x => x.MedicineId,
                        principalTable: "Medicines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PrescriptionsMedicines_Prescriptions_PrescriptionId",
                        column: x => x.PrescriptionId,
                        principalTable: "Prescriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Medicines",
                columns: new[] { "Id", "Name", "Notes" },
                values: new object[,]
                {
                    { 1, "Full revive", "Eat it or something idk" },
                    { 2, "Max potion", "Drink it or something idk" }
                });

            migrationBuilder.InsertData(
                table: "Prescriptions",
                columns: new[] { "Id", "AppointmentDoctorId", "AppointmentPatientId", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, 1, 2 },
                    { 2, 2, 2, 4 }
                });

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumns: new[] { "doctorid", "patientid" },
                keyValues: new object[] { 1, 1 },
                column: "booking_time",
                value: new DateTime(2024, 2, 5, 10, 37, 1, 96, DateTimeKind.Utc).AddTicks(5228));

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumns: new[] { "doctorid", "patientid" },
                keyValues: new object[] { 2, 2 },
                column: "booking_time",
                value: new DateTime(2024, 2, 5, 10, 37, 1, 96, DateTimeKind.Utc).AddTicks(5232));

            migrationBuilder.InsertData(
                table: "PrescriptionsMedicines",
                columns: new[] { "MedicineId", "PrescriptionId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 2, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PrescriptionsMedicines_MedicineId",
                table: "PrescriptionsMedicines",
                column: "MedicineId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PrescriptionsMedicines");

            migrationBuilder.DropTable(
                name: "Medicines");

            migrationBuilder.DropTable(
                name: "Prescriptions");

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumns: new[] { "doctorid", "patientid" },
                keyValues: new object[] { 1, 1 },
                column: "booking_time",
                value: new DateTime(2024, 2, 2, 10, 16, 58, 440, DateTimeKind.Utc).AddTicks(5826));

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumns: new[] { "doctorid", "patientid" },
                keyValues: new object[] { 2, 2 },
                column: "booking_time",
                value: new DateTime(2024, 2, 2, 10, 16, 58, 440, DateTimeKind.Utc).AddTicks(5828));
        }
    }
}
