using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Medecines",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medecines", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Prescriptions",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    patientid = table.Column<int>(type: "integer", nullable: false),
                    doctorid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescriptions", x => x.id);
                    table.ForeignKey(
                        name: "FK_Prescriptions_Appointments_doctorid_patientid",
                        columns: x => new { x.doctorid, x.patientid },
                        principalTable: "Appointments",
                        principalColumns: new[] { "patientid", "doctorid" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicinePrescriptions",
                columns: table => new
                {
                    perscriptionid = table.Column<int>(type: "integer", nullable: false),
                    medicineid = table.Column<int>(type: "integer", nullable: false),
                    quantity = table.Column<int>(type: "integer", nullable: false),
                    notes = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicinePrescriptions", x => new { x.perscriptionid, x.medicineid });
                    table.ForeignKey(
                        name: "FK_MedicinePrescriptions_Medecines_medicineid",
                        column: x => x.medicineid,
                        principalTable: "Medecines",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicinePrescriptions_Prescriptions_perscriptionid",
                        column: x => x.perscriptionid,
                        principalTable: "Prescriptions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumns: new[] { "doctorid", "patientid" },
                keyValues: new object[] { 2, 1 },
                column: "apointmentDate",
                value: new DateTime(2024, 9, 11, 13, 23, 18, 535, DateTimeKind.Utc).AddTicks(1200));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumns: new[] { "doctorid", "patientid" },
                keyValues: new object[] { 1, 2 },
                column: "apointmentDate",
                value: new DateTime(2024, 9, 11, 12, 53, 18, 535, DateTimeKind.Utc).AddTicks(1195));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumns: new[] { "doctorid", "patientid" },
                keyValues: new object[] { 5, 2 },
                column: "apointmentDate",
                value: new DateTime(2024, 9, 11, 13, 38, 18, 535, DateTimeKind.Utc).AddTicks(1212));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumns: new[] { "doctorid", "patientid" },
                keyValues: new object[] { 4, 3 },
                column: "apointmentDate",
                value: new DateTime(2024, 9, 11, 13, 53, 18, 535, DateTimeKind.Utc).AddTicks(1211));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumns: new[] { "doctorid", "patientid" },
                keyValues: new object[] { 3, 4 },
                column: "apointmentDate",
                value: new DateTime(2024, 9, 11, 13, 13, 18, 535, DateTimeKind.Utc).AddTicks(1214));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumns: new[] { "doctorid", "patientid" },
                keyValues: new object[] { 6, 5 },
                column: "apointmentDate",
                value: new DateTime(2024, 9, 11, 14, 23, 18, 535, DateTimeKind.Utc).AddTicks(1213));

            migrationBuilder.InsertData(
                table: "Medecines",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "Aspirin" },
                    { 2, "Ibuprofen" }
                });

            migrationBuilder.InsertData(
                table: "Prescriptions",
                columns: new[] { "id", "doctorid", "patientid" },
                values: new object[,]
                {
                    { 1, 1, 2 },
                    { 2, 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "MedicinePrescriptions",
                columns: new[] { "medicineid", "perscriptionid", "notes", "quantity" },
                values: new object[,]
                {
                    { 1, 1, "Take one daily", 10 },
                    { 2, 2, "Take three daily", 30 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MedicinePrescriptions_medicineid",
                table: "MedicinePrescriptions",
                column: "medicineid");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_doctorid_patientid",
                table: "Prescriptions",
                columns: new[] { "doctorid", "patientid" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicinePrescriptions");

            migrationBuilder.DropTable(
                name: "Medecines");

            migrationBuilder.DropTable(
                name: "Prescriptions");

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumns: new[] { "doctorid", "patientid" },
                keyValues: new object[] { 2, 1 },
                column: "apointmentDate",
                value: new DateTime(2024, 9, 9, 9, 17, 47, 128, DateTimeKind.Utc).AddTicks(40));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumns: new[] { "doctorid", "patientid" },
                keyValues: new object[] { 1, 2 },
                column: "apointmentDate",
                value: new DateTime(2024, 9, 9, 8, 47, 47, 128, DateTimeKind.Utc).AddTicks(37));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumns: new[] { "doctorid", "patientid" },
                keyValues: new object[] { 5, 2 },
                column: "apointmentDate",
                value: new DateTime(2024, 9, 9, 9, 32, 47, 128, DateTimeKind.Utc).AddTicks(50));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumns: new[] { "doctorid", "patientid" },
                keyValues: new object[] { 4, 3 },
                column: "apointmentDate",
                value: new DateTime(2024, 9, 9, 9, 47, 47, 128, DateTimeKind.Utc).AddTicks(49));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumns: new[] { "doctorid", "patientid" },
                keyValues: new object[] { 3, 4 },
                column: "apointmentDate",
                value: new DateTime(2024, 9, 9, 9, 7, 47, 128, DateTimeKind.Utc).AddTicks(53));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumns: new[] { "doctorid", "patientid" },
                keyValues: new object[] { 6, 5 },
                column: "apointmentDate",
                value: new DateTime(2024, 9, 9, 10, 17, 47, 128, DateTimeKind.Utc).AddTicks(52));
        }
    }
}
