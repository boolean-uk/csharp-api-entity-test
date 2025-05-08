using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
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
                    full_name = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    bijnaam = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patients", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "appointments",
                columns: table => new
                {
                    doctor_id = table.Column<int>(type: "integer", nullable: false),
                    patient_id = table.Column<int>(type: "integer", nullable: false),
                    bookings = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_appointments", x => new { x.doctor_id, x.patient_id });
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
                });

            migrationBuilder.InsertData(
                table: "doctors",
                columns: new[] { "id", "full_name" },
                values: new object[,]
                {
                    { 1, "John Doe" },
                    { 2, "Jane Doe" },
                    { 3, "John Smith" },
                    { 4, "Jane Smith" }
                });

            migrationBuilder.InsertData(
                table: "patients",
                columns: new[] { "id", "bijnaam", "email", "full_name" },
                values: new object[,]
                {
                    { 1, "A", "annadrijver.nl", "Anna Drijver" },
                    { 2, "A", "tomcruise.nl", "Tom Cruise" },
                    { 3, "A", "georginaverbaan.nl", "Gerogina Verbaan" },
                    { 4, "A", "daanschuurmans.nl", "Daan Schuurmans" }
                });

            migrationBuilder.InsertData(
                table: "appointments",
                columns: new[] { "doctor_id", "patient_id", "bookings" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 6, 13, 8, 28, 32, 579, DateTimeKind.Utc).AddTicks(6508) },
                    { 1, 4, new DateTime(2024, 6, 13, 8, 28, 32, 579, DateTimeKind.Utc).AddTicks(6520) },
                    { 2, 2, new DateTime(2024, 6, 13, 8, 28, 32, 579, DateTimeKind.Utc).AddTicks(6517) },
                    { 2, 3, new DateTime(2024, 6, 13, 8, 28, 32, 579, DateTimeKind.Utc).AddTicks(6522) },
                    { 3, 2, new DateTime(2024, 6, 13, 8, 28, 32, 579, DateTimeKind.Utc).AddTicks(6523) },
                    { 3, 3, new DateTime(2024, 6, 13, 8, 28, 32, 579, DateTimeKind.Utc).AddTicks(6518) },
                    { 4, 1, new DateTime(2024, 6, 13, 8, 28, 32, 579, DateTimeKind.Utc).AddTicks(6524) },
                    { 4, 4, new DateTime(2024, 6, 13, 8, 28, 32, 579, DateTimeKind.Utc).AddTicks(6519) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_appointments_patient_id",
                table: "appointments",
                column: "patient_id");
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
