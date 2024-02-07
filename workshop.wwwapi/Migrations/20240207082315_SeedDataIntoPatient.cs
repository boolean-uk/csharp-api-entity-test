using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataIntoPatient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "patients",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "Jack Peterson" },
                    { 2, "Dave Davidson" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "patients",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "patients",
                keyColumn: "id",
                keyValue: 2);
        }
    }
}
