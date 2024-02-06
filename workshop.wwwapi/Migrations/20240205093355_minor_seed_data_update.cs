using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class minor_seed_data_update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "prescription_medicine",
                columns: new[] { "MedicineId", "PrescriptionId", "amount", "instructions" },
                values: new object[,]
                {
                    { 1, 3, 10, "One dose each morning for 10 days." },
                    { 2, 3, 28, "2 pills each day for 2 weeks." },
                    { 3, 3, 10, "5 pills each day for 2 days." }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "prescription_medicine",
                keyColumns: new[] { "MedicineId", "PrescriptionId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "prescription_medicine",
                keyColumns: new[] { "MedicineId", "PrescriptionId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "prescription_medicine",
                keyColumns: new[] { "MedicineId", "PrescriptionId" },
                keyValues: new object[] { 3, 3 });
        }
    }
}
