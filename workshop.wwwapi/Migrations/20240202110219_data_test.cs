using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class data_test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    fk_doctor_id = table.Column<int>(type: "integer", nullable: false),
                    fk_patient_id = table.Column<int>(type: "integer", nullable: false),
                    date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PJ_appoitment_doctor_patient", x => new { x.fk_doctor_id, x.fk_patient_id });
                });

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

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "fk_doctor_id", "fk_patient_id", "date" },
                values: new object[,]
                {
                    { 1, 1, new DateTimeOffset(new DateTime(2024, 2, 3, 12, 2, 19, 544, DateTimeKind.Unspecified).AddTicks(144), new TimeSpan(0, 1, 0, 0, 0)) },
                    { 1, 2, new DateTimeOffset(new DateTime(2024, 2, 7, 12, 2, 19, 544, DateTimeKind.Unspecified).AddTicks(150), new TimeSpan(0, 1, 0, 0, 0)) },
                    { 2, 1, new DateTimeOffset(new DateTime(2024, 5, 2, 12, 2, 19, 544, DateTimeKind.Unspecified).AddTicks(153), new TimeSpan(0, 2, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "doctor_id", "full_name" },
                values: new object[,]
                {
                    { 1, "Oprah Obama" },
                    { 2, "Charles Winfrey" },
                    { 3, "Kate Windsor" },
                    { 4, "Kate Hepburn" },
                    { 5, "Jimi Presley" },
                    { 6, "Jimi Hendrix" },
                    { 7, "Kate Hendrix" },
                    { 8, "Charles Winfrey" },
                    { 9, "Audrey Winfrey" },
                    { 10, "Kate Jagger" },
                    { 11, "Audrey Presley" },
                    { 12, "Mick Presley" },
                    { 13, "Jimi Jagger" },
                    { 14, "Kate Windsor" },
                    { 15, "Elvis Presley" },
                    { 16, "Barack Windsor" },
                    { 17, "Kate Jagger" },
                    { 18, "Barack Jagger" },
                    { 19, "Jimi Hendrix" }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "patient_id", "full_name" },
                values: new object[,]
                {
                    { 1, "Kate Windsor" },
                    { 2, "Donald Obama" },
                    { 3, "Barack Winslet" },
                    { 4, "Charles Obama" },
                    { 5, "Kate Trump" },
                    { 6, "Barack Middleton" },
                    { 7, "Kate Obama" },
                    { 8, "Jimi Winfrey" },
                    { 9, "Oprah Winslet" },
                    { 10, "Oprah Winslet" },
                    { 11, "Elvis Obama" },
                    { 12, "Barack Winslet" },
                    { 13, "Donald Presley" },
                    { 14, "Barack Obama" },
                    { 15, "Donald Winslet" },
                    { 16, "Audrey Winslet" },
                    { 17, "Barack Presley" },
                    { 18, "Oprah Middleton" },
                    { 19, "Elvis Hepburn" }
                });
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
