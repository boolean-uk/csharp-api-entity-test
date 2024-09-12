using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class secondmig : Migration
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
                keyValues: new object[] { 1, 2 },
                column: "booking",
                value: new DateTime(2024, 9, 12, 7, 51, 41, 492, DateTimeKind.Utc).AddTicks(3056));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumns: new[] { "doctorid", "patientid" },
                keyValues: new object[] { 2, 2 },
                column: "booking",
                value: new DateTime(2024, 9, 12, 7, 21, 41, 492, DateTimeKind.Utc).AddTicks(3053));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumns: new[] { "doctorid", "patientid" },
                keyValues: new object[] { 2, 3 },
                column: "booking",
                value: new DateTime(2024, 9, 12, 8, 21, 41, 492, DateTimeKind.Utc).AddTicks(3066));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumns: new[] { "doctorid", "patientid" },
                keyValues: new object[] { 2, 4 },
                column: "booking",
                value: new DateTime(2024, 9, 12, 8, 6, 41, 492, DateTimeKind.Utc).AddTicks(3071));

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "doctorid", "patientid", "booking" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 9, 12, 8, 21, 41, 492, DateTimeKind.Utc).AddTicks(3069) },
                    { 2, 1, new DateTime(2024, 9, 12, 8, 21, 41, 492, DateTimeKind.Utc).AddTicks(3068) }
                });

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
                values: new object[] { 2, 2, 1 });

            migrationBuilder.InsertData(
                table: "MedicinePrescriptions",
                columns: new[] { "medicineid", "perscriptionid", "notes", "quantity" },
                values: new object[] { 2, 2, "Take three daily", 30 });

            migrationBuilder.InsertData(
                table: "Prescriptions",
                columns: new[] { "id", "doctorid", "patientid" },
                values: new object[] { 1, 1, 2 });

            migrationBuilder.InsertData(
                table: "MedicinePrescriptions",
                columns: new[] { "medicineid", "perscriptionid", "notes", "quantity" },
                values: new object[] { 1, 1, "Take one daily", 10 });

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

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumns: new[] { "doctorid", "patientid" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumns: new[] { "doctorid", "patientid" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumns: new[] { "doctorid", "patientid" },
                keyValues: new object[] { 1, 2 },
                column: "booking",
                value: new DateTime(2024, 9, 9, 9, 43, 3, 334, DateTimeKind.Utc).AddTicks(6121));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumns: new[] { "doctorid", "patientid" },
                keyValues: new object[] { 2, 2 },
                column: "booking",
                value: new DateTime(2024, 9, 9, 9, 13, 3, 334, DateTimeKind.Utc).AddTicks(6119));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumns: new[] { "doctorid", "patientid" },
                keyValues: new object[] { 2, 3 },
                column: "booking",
                value: new DateTime(2024, 9, 9, 10, 13, 3, 334, DateTimeKind.Utc).AddTicks(6126));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumns: new[] { "doctorid", "patientid" },
                keyValues: new object[] { 2, 4 },
                column: "booking",
                value: new DateTime(2024, 9, 9, 9, 58, 3, 334, DateTimeKind.Utc).AddTicks(6128));
        }
    }
}
