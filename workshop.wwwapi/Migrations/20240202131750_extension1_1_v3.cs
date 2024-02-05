using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class extension1_1_v3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "amount",
                table: "prescription");

            migrationBuilder.DropColumn(
                name: "instructions",
                table: "prescription");

            migrationBuilder.AddColumn<int>(
                name: "amount",
                table: "medicine",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "instructions",
                table: "medicine",
                type: "character varying(511)",
                maxLength: 511,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "medicine",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "amount", "instructions" },
                values: new object[] { 42, "One dose each morning for 3 weeks." });

            migrationBuilder.UpdateData(
                table: "medicine",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "amount", "instructions" },
                values: new object[] { 28, "2 pills each day for 2 weeks." });

            migrationBuilder.UpdateData(
                table: "medicine",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "amount", "instructions" },
                values: new object[] { 10, "5 pills each day for 2 days." });

            migrationBuilder.InsertData(
                table: "prescription_medicine",
                columns: new[] { "MedicineId", "PrescriptionId" },
                values: new object[] { 2, 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "prescription_medicine",
                keyColumns: new[] { "MedicineId", "PrescriptionId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DropColumn(
                name: "amount",
                table: "medicine");

            migrationBuilder.DropColumn(
                name: "instructions",
                table: "medicine");

            migrationBuilder.AddColumn<int>(
                name: "amount",
                table: "prescription",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "instructions",
                table: "prescription",
                type: "character varying(511)",
                maxLength: 511,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "prescription",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "amount", "instructions" },
                values: new object[] { 42, "One dose each morning for 3 weeks." });

            migrationBuilder.UpdateData(
                table: "prescription",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "amount", "instructions" },
                values: new object[] { 28, "2 pills each day for 2 weeks." });
        }
    }
}
