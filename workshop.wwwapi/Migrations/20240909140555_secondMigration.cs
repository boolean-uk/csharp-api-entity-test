using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class secondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "appointments",
                columns: table => new
                {
                    doctorId = table.Column<int>(type: "integer", nullable: false),
                    patientId = table.Column<int>(type: "integer", nullable: false),
                    perscriptionId = table.Column<int>(type: "integer", nullable: false),
                    id = table.Column<int>(type: "integer", nullable: false),
                    booking = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_appointments", x => new { x.doctorId, x.patientId, x.perscriptionId });
                });

            migrationBuilder.CreateTable(
                name: "doctors",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_doctors", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "medicine",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    quantity = table.Column<int>(type: "integer", nullable: false),
                    instruction = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medicine", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "patients",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patients", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "perscription",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_perscription", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "PerscriptionsMedicines",
                columns: table => new
                {
                    medicineId = table.Column<int>(type: "integer", nullable: false),
                    perscriptionId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerscriptionsMedicines", x => new { x.medicineId, x.perscriptionId });
                    table.ForeignKey(
                        name: "FK_PerscriptionsMedicines_medicine_medicineId",
                        column: x => x.medicineId,
                        principalTable: "medicine",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PerscriptionsMedicines_perscription_perscriptionId",
                        column: x => x.perscriptionId,
                        principalTable: "perscription",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "appointments",
                columns: new[] { "doctorId", "patientId", "perscriptionId", "booking", "id" },
                values: new object[,]
                {
                    { 1, 2, 2, new DateTime(2025, 7, 13, 15, 35, 3, 423, DateTimeKind.Utc).AddTicks(5181), 2 },
                    { 3, 1, 1, new DateTime(2024, 11, 16, 12, 51, 9, 423, DateTimeKind.Utc).AddTicks(5113), 1 },
                    { 4, 3, 3, new DateTime(2024, 10, 17, 21, 27, 30, 423, DateTimeKind.Utc).AddTicks(5189), 3 },
                    { 4, 4, 1, new DateTime(2025, 5, 30, 1, 35, 25, 423, DateTimeKind.Utc).AddTicks(5193), 4 }
                });

            migrationBuilder.InsertData(
                table: "doctors",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "Oprah Obama" },
                    { 2, "Mick Winfrey" },
                    { 3, "Audrey Jagger" },
                    { 4, "Mick Hendrix" }
                });

            migrationBuilder.InsertData(
                table: "medicine",
                columns: new[] { "id", "instruction", "name", "quantity" },
                values: new object[,]
                {
                    { 1, "Crush and mix with sand", "Ultra Pills", 2 },
                    { 2, "Swallow with sand", "Good Mold", 8 },
                    { 3, "Apply on your face and then take some sand", "Super Laxatives", 8 },
                    { 4, "Inject into arm and then take some cocaine", "Ultra Candy", 5 }
                });

            migrationBuilder.InsertData(
                table: "patients",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "Oprah Winfrey" },
                    { 2, "Kate Winslet" },
                    { 3, "Oprah Winfrey" },
                    { 4, "Jimi Winfrey" }
                });

            migrationBuilder.InsertData(
                table: "perscription",
                column: "id",
                values: new object[]
                {
                    1,
                    2,
                    3,
                    4
                });

            migrationBuilder.InsertData(
                table: "PerscriptionsMedicines",
                columns: new[] { "medicineId", "perscriptionId" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 1, 4 },
                    { 2, 1 },
                    { 2, 3 },
                    { 3, 3 },
                    { 3, 4 },
                    { 4, 1 },
                    { 4, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PerscriptionsMedicines_perscriptionId",
                table: "PerscriptionsMedicines",
                column: "perscriptionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PerscriptionsMedicines");

            migrationBuilder.DropTable(
                name: "appointments");

            migrationBuilder.DropTable(
                name: "doctors");

            migrationBuilder.DropTable(
                name: "patients");

            migrationBuilder.DropTable(
                name: "medicine");

            migrationBuilder.DropTable(
                name: "perscription");
        }
    }
}
