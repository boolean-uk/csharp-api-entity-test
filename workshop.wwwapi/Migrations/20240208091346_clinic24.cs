using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class clinic24 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_medicinPerscriptions_medicine_MedicineId",
                table: "medicinPerscriptions");

            migrationBuilder.DropColumn(
                name: "medicinid",
                table: "medicinPerscriptions");

            migrationBuilder.RenameColumn(
                name: "MedicineId",
                table: "medicinPerscriptions",
                newName: "medicineid");

            migrationBuilder.RenameIndex(
                name: "IX_medicinPerscriptions_MedicineId",
                table: "medicinPerscriptions",
                newName: "IX_medicinPerscriptions_medicineid");

            migrationBuilder.AddForeignKey(
                name: "FK_medicinPerscriptions_medicine_medicineid",
                table: "medicinPerscriptions",
                column: "medicineid",
                principalTable: "medicine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_medicinPerscriptions_medicine_medicineid",
                table: "medicinPerscriptions");

            migrationBuilder.RenameColumn(
                name: "medicineid",
                table: "medicinPerscriptions",
                newName: "MedicineId");

            migrationBuilder.RenameIndex(
                name: "IX_medicinPerscriptions_medicineid",
                table: "medicinPerscriptions",
                newName: "IX_medicinPerscriptions_MedicineId");

            migrationBuilder.AddColumn<int>(
                name: "medicinid",
                table: "medicinPerscriptions",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_medicinPerscriptions_medicine_MedicineId",
                table: "medicinPerscriptions",
                column: "MedicineId",
                principalTable: "medicine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
