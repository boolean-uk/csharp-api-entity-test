using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class SeedingPatients : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "patient",
                columns: new[] { "id", "fullname" },
                values: new object[,]
                {
                    { 1, "Klas Bengtsson" },
                    { 2, "Kerstin Gunnarsson" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "patient",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "patient",
                keyColumn: "id",
                keyValue: 2);
        }
    }
}
