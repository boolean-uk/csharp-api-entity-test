using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class MorePrescribedMeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "PrescribedMedicines",
                columns: new[] { "Id", "Amount", "Instructions", "MedicineName", "PrescriptionId" },
                values: new object[,]
                {
                    { 4, 1, "Take 1 after deployment", "Bugfixol", 2 },
                    { 5, 1, "Take 1 daily", "Patchorix", 2 },
                    { 6, 2, "Take as reward when writing lambda functions", "LambdaRelief", 2 },
                    { 7, 1, "Take 1 when forgetting LINQ syntax", "Syntaxol", 3 },
                    { 8, 2, "Take 2 when compiling fails", "Compilex", 3 },
                    { 9, 1, "Take with food, or drink, or rub on skin", "PolyMorphix", 3 },
                    { 10, 1, "Take as reward when writing lambda functions", "LambdaRelief", 4 },
                    { 11, 2, "Take 2 when using abstract classes", "Inheritex", 4 },
                    { 12, 1, "Take 1 and brace for frontend week!", "Reactabool Forte", 4 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PrescribedMedicines",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PrescribedMedicines",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "PrescribedMedicines",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "PrescribedMedicines",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "PrescribedMedicines",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "PrescribedMedicines",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "PrescribedMedicines",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "PrescribedMedicines",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "PrescribedMedicines",
                keyColumn: "Id",
                keyValue: 12);
        }
    }
}
