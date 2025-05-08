using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class clinic12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MedicinPerscription",
                table: "MedicinPerscription");

            migrationBuilder.RenameTable(
                name: "MedicinPerscription",
                newName: "medicinPerscriptions");

            migrationBuilder.AddPrimaryKey(
                name: "PK_medicinPerscriptions",
                table: "medicinPerscriptions",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_medicinPerscriptions_perscriptionid",
                table: "medicinPerscriptions",
                column: "perscriptionid");

            migrationBuilder.AddForeignKey(
                name: "FK_medicinPerscriptions_perscription_perscriptionid",
                table: "medicinPerscriptions",
                column: "perscriptionid",
                principalTable: "perscription",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_medicinPerscriptions_perscription_perscriptionid",
                table: "medicinPerscriptions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_medicinPerscriptions",
                table: "medicinPerscriptions");

            migrationBuilder.DropIndex(
                name: "IX_medicinPerscriptions_perscriptionid",
                table: "medicinPerscriptions");

            migrationBuilder.RenameTable(
                name: "medicinPerscriptions",
                newName: "MedicinPerscription");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MedicinPerscription",
                table: "MedicinPerscription",
                column: "Id");
        }
    }
}
