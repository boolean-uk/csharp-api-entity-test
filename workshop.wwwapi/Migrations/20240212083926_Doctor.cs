using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class Doctor : Migration
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
                name: "Patient",
                columns: table => new
                {
                    patient_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    full_name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.patient_id);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    booking_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    fk_doctor_id = table.Column<int>(type: "integer", nullable: false),
                    fk_patient_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_appointment_doc_patient_booking", x => new { x.fk_patient_id, x.fk_doctor_id, x.booking_time });
                    table.ForeignKey(
                        name: "FK_Appointments_Doctors_fk_doctor_id",
                        column: x => x.fk_doctor_id,
                        principalTable: "Doctors",
                        principalColumn: "doctor_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_Patient_fk_patient_id",
                        column: x => x.fk_patient_id,
                        principalTable: "Patient",
                        principalColumn: "patient_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "doctor_id", "full_name" },
                values: new object[,]
                {
                    { 1, "Edison McGallan" },
                    { 2, "Will Space" },
                    { 3, "Clyde Tesla" },
                    { 4, "Freddy Lecter" },
                    { 5, "Hannibal McGallan" },
                    { 6, "Andy Tesla" },
                    { 7, "Freddy Space" },
                    { 8, "Crueger Tesla" },
                    { 9, "Graham Crawford" },
                    { 10, "Will Tesla" },
                    { 11, "Bonnie Space" },
                    { 12, "Graham Tesla" },
                    { 13, "Jekyll Trumpet" },
                    { 14, "Bonnie Lecter" },
                    { 15, "Freddy Lecter" },
                    { 16, "Jekyll Space" },
                    { 17, "Andy Trumpet" },
                    { 18, "Bonnie Crawford" },
                    { 19, "Clyde Space" },
                    { 20, "Will Crawford" }
                });

            migrationBuilder.InsertData(
                table: "Patient",
                columns: new[] { "patient_id", "full_name" },
                values: new object[,]
                {
                    { 1, "Will Crawford" },
                    { 2, "Andy Doofenschmitz" },
                    { 3, "Jekyll Lecter" },
                    { 4, "Edison Reed" },
                    { 5, "Freddy McGallan" },
                    { 6, "Andy Doofenschmitz" },
                    { 7, "Lisa Space" },
                    { 8, "Freddy Trumpet" },
                    { 9, "Edison Lecter" },
                    { 10, "Andy Reed" },
                    { 11, "Freddy Tesla" },
                    { 12, "Graham Crawford" },
                    { 13, "Graham Lecter" },
                    { 14, "Bonnie Space" },
                    { 15, "Will Doofenschmitz" },
                    { 16, "Clyde Crawford" },
                    { 17, "Jekyll Crawford" },
                    { 18, "Bonnie Lecter" },
                    { 19, "Lisa Lecter" },
                    { 20, "Andy Crawford" }
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "booking_time", "fk_doctor_id", "fk_patient_id" },
                values: new object[,]
                {
                    { new DateTime(2001, 1, 1, 23, 0, 0, 0, DateTimeKind.Utc), 3, 1 },
                    { new DateTime(2002, 1, 2, 23, 0, 0, 0, DateTimeKind.Utc), 2, 3 },
                    { new DateTime(2002, 2, 2, 23, 0, 0, 0, DateTimeKind.Utc), 4, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_fk_doctor_id",
                table: "Appointments",
                column: "fk_doctor_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Patient");
        }
    }
}
