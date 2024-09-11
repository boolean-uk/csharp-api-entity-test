using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class AppointmentAndMedicineTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "booking", "doctor_id", "patient_id" },
                keyValues: new object[] { new DateTime(2024, 1, 31, 12, 10, 9, 961, DateTimeKind.Utc).AddTicks(3855), 1, 2 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "booking", "doctor_id", "patient_id" },
                keyValues: new object[] { new DateTime(2024, 1, 31, 12, 10, 9, 961, DateTimeKind.Utc).AddTicks(3860), 2, 2 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "booking", "doctor_id", "patient_id" },
                keyValues: new object[] { new DateTime(2024, 1, 31, 12, 10, 9, 961, DateTimeKind.Utc).AddTicks(3861), 1, 2 });

            migrationBuilder.AddColumn<int>(
                name: "PrescriptionId",
                table: "appointments",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Medicines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    Note = table.Column<string>(type: "text", nullable: false)
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
                    AppoinmentId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescriptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicinePrescription",
                columns: table => new
                {
                    MedicinesId = table.Column<int>(type: "integer", nullable: false),
                    PrescriptionsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicinePrescription", x => new { x.MedicinesId, x.PrescriptionsId });
                    table.ForeignKey(
                        name: "FK_MedicinePrescription_Medicines_MedicinesId",
                        column: x => x.MedicinesId,
                        principalTable: "Medicines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicinePrescription_Prescriptions_PrescriptionsId",
                        column: x => x.PrescriptionsId,
                        principalTable: "Prescriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "appointments",
                columns: new[] { "booking", "doctor_id", "patient_id", "PrescriptionId" },
                values: new object[,]
                {
                    { new DateTime(2024, 2, 8, 11, 58, 10, 281, DateTimeKind.Utc).AddTicks(8171), 1, 2, null },
                    { new DateTime(2024, 2, 8, 11, 58, 10, 281, DateTimeKind.Utc).AddTicks(8177), 2, 1, null },
                    { new DateTime(2024, 2, 8, 11, 58, 10, 281, DateTimeKind.Utc).AddTicks(8178), 2, 2, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_appointments_PrescriptionId",
                table: "appointments",
                column: "PrescriptionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MedicinePrescription_PrescriptionsId",
                table: "MedicinePrescription",
                column: "PrescriptionsId");

            migrationBuilder.AddForeignKey(
                name: "FK_appointments_Prescriptions_PrescriptionId",
                table: "appointments",
                column: "PrescriptionId",
                principalTable: "Prescriptions",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_appointments_Prescriptions_PrescriptionId",
                table: "appointments");

            migrationBuilder.DropTable(
                name: "MedicinePrescription");

            migrationBuilder.DropTable(
                name: "Medicines");

            migrationBuilder.DropTable(
                name: "Prescriptions");

            migrationBuilder.DropIndex(
                name: "IX_appointments_PrescriptionId",
                table: "appointments");

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "booking", "doctor_id", "patient_id" },
                keyValues: new object[] { new DateTime(2024, 2, 8, 11, 58, 10, 281, DateTimeKind.Utc).AddTicks(8171), 1, 2 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "booking", "doctor_id", "patient_id" },
                keyValues: new object[] { new DateTime(2024, 2, 8, 11, 58, 10, 281, DateTimeKind.Utc).AddTicks(8177), 2, 1 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "booking", "doctor_id", "patient_id" },
                keyValues: new object[] { new DateTime(2024, 2, 8, 11, 58, 10, 281, DateTimeKind.Utc).AddTicks(8178), 2, 2 });

            migrationBuilder.DropColumn(
                name: "PrescriptionId",
                table: "appointments");

            migrationBuilder.InsertData(
                table: "appointments",
                columns: new[] { "booking", "doctor_id", "patient_id" },
                values: new object[,]
                {
                    { new DateTime(2024, 1, 31, 12, 10, 9, 961, DateTimeKind.Utc).AddTicks(3855), 1, 2 },
                    { new DateTime(2024, 1, 31, 12, 10, 9, 961, DateTimeKind.Utc).AddTicks(3860), 2, 2 },
                    { new DateTime(2024, 1, 31, 12, 10, 9, 961, DateTimeKind.Utc).AddTicks(3861), 1, 2 }
                });
        }
    }
}
