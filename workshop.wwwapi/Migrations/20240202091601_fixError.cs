using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class fixError : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    doctor_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    full_name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.doctor_id);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    patient_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    full_name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.patient_id);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    fk_doctor_id = table.Column<int>(type: "integer", nullable: false),
                    fk_patient_id = table.Column<int>(type: "integer", nullable: false),
                    booking = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_appointment_doctor_patient", x => new { x.fk_doctor_id, x.fk_patient_id });
                    table.ForeignKey(
                        name: "FK_Appointments_Doctors_fk_doctor_id",
                        column: x => x.fk_doctor_id,
                        principalTable: "Doctors",
                        principalColumn: "doctor_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_Patients_fk_patient_id",
                        column: x => x.fk_patient_id,
                        principalTable: "Patients",
                        principalColumn: "patient_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "doctor_id", "full_name" },
                values: new object[,]
                {
                    { 1, "Dr. Heinz Doofenshmirtz" },
                    { 2, "Dr Johnny" }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "patient_id", "full_name" },
                values: new object[,]
                {
                    { 1, "John Doe" },
                    { 2, "Jane Smith" }
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "fk_doctor_id", "fk_patient_id", "booking" },
                values: new object[,]
                {
                    { 1, 1, new DateTimeOffset(new DateTime(2024, 2, 3, 10, 16, 1, 692, DateTimeKind.Unspecified).AddTicks(5896), new TimeSpan(0, 1, 0, 0, 0)) },
                    { 1, 2, new DateTimeOffset(new DateTime(2024, 2, 7, 10, 16, 1, 692, DateTimeKind.Unspecified).AddTicks(5959), new TimeSpan(0, 1, 0, 0, 0)) },
                    { 2, 1, new DateTimeOffset(new DateTime(2024, 5, 2, 10, 16, 1, 692, DateTimeKind.Unspecified).AddTicks(5963), new TimeSpan(0, 2, 0, 0, 0)) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_fk_patient_id",
                table: "Appointments",
                column: "fk_patient_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Patients");
        }
    }
}
