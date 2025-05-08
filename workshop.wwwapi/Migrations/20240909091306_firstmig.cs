using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class firstmig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    fullname = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    fullname = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    doctorid = table.Column<int>(type: "integer", nullable: false),
                    patientid = table.Column<int>(type: "integer", nullable: false),
                    booking = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => new { x.patientid, x.doctorid });
                    table.ForeignKey(
                        name: "FK_Appointments_Doctors_doctorid",
                        column: x => x.doctorid,
                        principalTable: "Doctors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_Patients_patientid",
                        column: x => x.patientid,
                        principalTable: "Patients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "id", "fullname" },
                values: new object[,]
                {
                    { 1, "Doctor Osmani" },
                    { 2, "Doctor Flier" }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "id", "fullname" },
                values: new object[,]
                {
                    { 1, "Dennis" },
                    { 2, "Thomas" },
                    { 3, "Ali" },
                    { 4, "Melvin" }
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "doctorid", "patientid", "booking" },
                values: new object[,]
                {
                    { 1, 2, new DateTime(2024, 9, 9, 9, 43, 3, 334, DateTimeKind.Utc).AddTicks(6121) },
                    { 2, 2, new DateTime(2024, 9, 9, 9, 13, 3, 334, DateTimeKind.Utc).AddTicks(6119) },
                    { 2, 3, new DateTime(2024, 9, 9, 10, 13, 3, 334, DateTimeKind.Utc).AddTicks(6126) },
                    { 2, 4, new DateTime(2024, 9, 9, 9, 58, 3, 334, DateTimeKind.Utc).AddTicks(6128) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_doctorid",
                table: "Appointments",
                column: "doctorid");
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
