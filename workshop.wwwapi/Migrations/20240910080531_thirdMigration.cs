using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class thirdMigration : Migration
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
                name: "perscriptionMedicines",
                columns: table => new
                {
                    medicineId = table.Column<int>(type: "integer", nullable: false),
                    perscriptionId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_perscriptionMedicines", x => new { x.medicineId, x.perscriptionId });
                    table.ForeignKey(
                        name: "FK_perscriptionMedicines_medicine_medicineId",
                        column: x => x.medicineId,
                        principalTable: "medicine",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_perscriptionMedicines_perscription_perscriptionId",
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
                    { 1, 3, 3, new DateTime(2025, 1, 21, 17, 29, 19, 64, DateTimeKind.Utc).AddTicks(9854), 3 },
                    { 2, 4, 4, new DateTime(2024, 10, 21, 10, 38, 53, 64, DateTimeKind.Utc).AddTicks(9857), 4 },
                    { 4, 1, 1, new DateTime(2025, 3, 30, 1, 2, 35, 64, DateTimeKind.Utc).AddTicks(9753), 1 },
                    { 4, 2, 2, new DateTime(2024, 10, 23, 5, 30, 53, 64, DateTimeKind.Utc).AddTicks(9848), 2 }
                });

            migrationBuilder.InsertData(
                table: "doctors",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "Barack Middleton" },
                    { 2, "Donald Hendrix" },
                    { 3, "Barack Windsor" },
                    { 4, "Charles Winfrey" }
                });

            migrationBuilder.InsertData(
                table: "medicine",
                columns: new[] { "id", "instruction", "name", "quantity" },
                values: new object[,]
                {
                    { 1, "Eat with chinese chicken stock", "Blazing Paracetamol", 3 },
                    { 2, "Apply on your face and then take some air", "Dangerous Paracetamol", 5 },
                    { 3, "Dilute with cooking Oil", "Super Laxatives", 8 },
                    { 4, "Eat with cocaine", "Dangerous Mold", 3 }
                });

            migrationBuilder.InsertData(
                table: "patients",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "Jimi Trump" },
                    { 2, "Barack Trump" },
                    { 3, "Donald Hepburn" },
                    { 4, "Barack Presley" }
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
                table: "perscriptionMedicines",
                columns: new[] { "medicineId", "perscriptionId" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 1, 3 },
                    { 2, 1 },
                    { 2, 4 },
                    { 3, 1 },
                    { 3, 2 },
                    { 4, 1 },
                    { 4, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_perscriptionMedicines_perscriptionId",
                table: "perscriptionMedicines",
                column: "perscriptionId");
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

            migrationBuilder.DropTable(
                name: "perscriptionMedicines");

            migrationBuilder.DropTable(
                name: "medicine");

            migrationBuilder.DropTable(
                name: "perscription");
        }
    }
}
