using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class AddPredMed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "medicine",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medicine", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "prescription",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_prescription", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "prescript",
                columns: table => new
                {
                    MedicineId = table.Column<int>(type: "integer", nullable: false),
                    PrescriptionId = table.Column<int>(type: "integer", nullable: false),
                    Quatity = table.Column<int>(type: "integer", nullable: false),
                    Note = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_prescript", x => new { x.MedicineId, x.PrescriptionId });
                    table.ForeignKey(
                        name: "FK_prescript_medicine_MedicineId",
                        column: x => x.MedicineId,
                        principalTable: "medicine",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_prescript_prescription_PrescriptionId",
                        column: x => x.PrescriptionId,
                        principalTable: "prescription",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "medicine",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "Coke" },
                    { 2, "80%" },
                    { 3, "LOL" }
                });

            migrationBuilder.InsertData(
                table: "prescription",
                column: "id",
                values: new object[]
                {
                    1,
                    2,
                    3
                });

            migrationBuilder.InsertData(
                table: "prescript",
                columns: new[] { "MedicineId", "PrescriptionId", "Note", "Quatity" },
                values: new object[,]
                {
                    { 1, 1, "TAKE THIS WITH CARE", 100 },
                    { 2, 2, "OVERDOSE", 1000 },
                    { 3, 3, "TAKE MORE", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_prescript_PrescriptionId",
                table: "prescript",
                column: "PrescriptionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "prescript");

            migrationBuilder.DropTable(
                name: "medicine");

            migrationBuilder.DropTable(
                name: "prescription");
        }
    }
}
