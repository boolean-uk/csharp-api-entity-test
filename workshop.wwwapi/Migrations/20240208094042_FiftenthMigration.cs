using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class FiftenthMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "medicines",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    notes = table.Column<string>(type: "text", nullable: false),
                    quantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medicines", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "perscriptions",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_perscriptions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "medicineperscriptions",
                columns: table => new
                {
                    medicineid = table.Column<int>(type: "integer", nullable: false),
                    perscriptionid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medicineperscriptions", x => new { x.medicineid, x.perscriptionid });
                    table.ForeignKey(
                        name: "FK_medicineperscriptions_medicines_medicineid",
                        column: x => x.medicineid,
                        principalTable: "medicines",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_medicineperscriptions_perscriptions_perscriptionid",
                        column: x => x.perscriptionid,
                        principalTable: "perscriptions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumns: new[] { "doctorid", "patientid" },
                keyValues: new object[] { 1, 1 },
                column: "booking",
                value: new DateTime(2024, 2, 9, 9, 40, 41, 835, DateTimeKind.Utc).AddTicks(3956));

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumns: new[] { "doctorid", "patientid" },
                keyValues: new object[] { 2, 2 },
                column: "booking",
                value: new DateTime(2024, 2, 10, 9, 40, 41, 835, DateTimeKind.Utc).AddTicks(3970));

            migrationBuilder.CreateIndex(
                name: "IX_medicineperscriptions_perscriptionid",
                table: "medicineperscriptions",
                column: "perscriptionid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "medicineperscriptions");

            migrationBuilder.DropTable(
                name: "medicines");

            migrationBuilder.DropTable(
                name: "perscriptions");

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumns: new[] { "doctorid", "patientid" },
                keyValues: new object[] { 1, 1 },
                column: "booking",
                value: new DateTime(2024, 2, 8, 13, 43, 42, 999, DateTimeKind.Utc).AddTicks(8776));

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumns: new[] { "doctorid", "patientid" },
                keyValues: new object[] { 2, 2 },
                column: "booking",
                value: new DateTime(2024, 2, 9, 13, 43, 42, 999, DateTimeKind.Utc).AddTicks(8793));
        }
    }
}
