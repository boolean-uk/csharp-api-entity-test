using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class Seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "patients",
                columns: new[] { "id", "fullname" },
                values: new object[,]
                {
                    { 1, "Java Script" },
                    { 2, "C Sharp" }
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
