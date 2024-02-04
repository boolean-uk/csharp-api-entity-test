using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class AddMedinePrescriptions2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "prescription_id",
                table: "appointments",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "type",
                table: "appointments",
                type: "text",
                nullable: false,
                defaultValue: "");

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
                name: "prescriptions",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    quantity = table.Column<int>(type: "integer", nullable: false),
                    notes = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_prescriptions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "medicineprescriptions",
                columns: table => new
                {
                    medicine_id = table.Column<int>(type: "integer", nullable: false),
                    prescription_id = table.Column<int>(type: "integer", nullable: false),
                    id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medicineprescriptions", x => new { x.medicine_id, x.prescription_id });
                    table.ForeignKey(
                        name: "FK_medicineprescriptions_medicines_medicine_id",
                        column: x => x.medicine_id,
                        principalTable: "medicines",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_medicineprescriptions_prescriptions_prescription_id",
                        column: x => x.prescription_id,
                        principalTable: "prescriptions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumns: new[] { "doctor_id", "patient_id" },
                keyValues: new object[] { 1, 1 },
                columns: new[] { "booking", "prescription_id", "type" },
                values: new object[] { new DateTime(2024, 2, 4, 16, 15, 2, 163, DateTimeKind.Utc).AddTicks(5864), 1, "online" });

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumns: new[] { "doctor_id", "patient_id" },
                keyValues: new object[] { 1, 2 },
                columns: new[] { "booking", "prescription_id", "type" },
                values: new object[] { new DateTime(2024, 2, 4, 16, 15, 2, 163, DateTimeKind.Utc).AddTicks(6069), 4, "2nd floor, room 12" });

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumns: new[] { "doctor_id", "patient_id" },
                keyValues: new object[] { 2, 2 },
                columns: new[] { "booking", "prescription_id", "type" },
                values: new object[] { new DateTime(2024, 2, 4, 16, 15, 2, 163, DateTimeKind.Utc).AddTicks(6026), 2, "3rd floor room 34" });

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumns: new[] { "doctor_id", "patient_id" },
                keyValues: new object[] { 2, 3 },
                columns: new[] { "booking", "prescription_id", "type" },
                values: new object[] { new DateTime(2024, 2, 4, 16, 15, 2, 163, DateTimeKind.Utc).AddTicks(6064), 3, "online" });

            migrationBuilder.InsertData(
                table: "medicines",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "Melatonin" },
                    { 2, "Ibuprofen" },
                    { 3, "Penicillin" }
                });

            migrationBuilder.InsertData(
                table: "prescriptions",
                columns: new[] { "id", "notes", "quantity" },
                values: new object[,]
                {
                    { 1, "Take 3 per day", 1 },
                    { 2, "Twice a week", 12 },
                    { 3, "Use when needed", 3 }
                });

            migrationBuilder.InsertData(
                table: "medicineprescriptions",
                columns: new[] { "medicine_id", "prescription_id", "id" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 4 },
                    { 2, 2, 2 },
                    { 3, 2, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_appointments_prescription_id",
                table: "appointments",
                column: "prescription_id");

            migrationBuilder.CreateIndex(
                name: "IX_medicineprescriptions_prescription_id",
                table: "medicineprescriptions",
                column: "prescription_id");

            migrationBuilder.AddForeignKey(
                name: "FK_appointments_prescriptions_prescription_id",
                table: "appointments",
                column: "prescription_id",
                principalTable: "prescriptions",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_appointments_prescriptions_prescription_id",
                table: "appointments");

            migrationBuilder.DropTable(
                name: "medicineprescriptions");

            migrationBuilder.DropTable(
                name: "medicines");

            migrationBuilder.DropTable(
                name: "prescriptions");

            migrationBuilder.DropIndex(
                name: "IX_appointments_prescription_id",
                table: "appointments");

            migrationBuilder.DropColumn(
                name: "prescription_id",
                table: "appointments");

            migrationBuilder.DropColumn(
                name: "type",
                table: "appointments");

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumns: new[] { "doctor_id", "patient_id" },
                keyValues: new object[] { 1, 1 },
                column: "booking",
                value: new DateTime(2024, 1, 31, 14, 52, 45, 950, DateTimeKind.Local).AddTicks(633));

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumns: new[] { "doctor_id", "patient_id" },
                keyValues: new object[] { 1, 2 },
                column: "booking",
                value: new DateTime(2024, 1, 31, 14, 52, 45, 950, DateTimeKind.Local).AddTicks(731));

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumns: new[] { "doctor_id", "patient_id" },
                keyValues: new object[] { 2, 2 },
                column: "booking",
                value: new DateTime(2024, 1, 31, 14, 52, 45, 950, DateTimeKind.Local).AddTicks(692));

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumns: new[] { "doctor_id", "patient_id" },
                keyValues: new object[] { 2, 3 },
                column: "booking",
                value: new DateTime(2024, 1, 31, 14, 52, 45, 950, DateTimeKind.Local).AddTicks(727));
        }
    }
}
