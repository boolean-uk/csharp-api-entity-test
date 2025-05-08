using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class clinic20 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MedicineId",
                table: "medicinPerscriptions",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_perscription_doctorid",
                table: "perscription",
                column: "doctorid");

            migrationBuilder.CreateIndex(
                name: "IX_perscription_patientid",
                table: "perscription",
                column: "patientid");

            migrationBuilder.CreateIndex(
                name: "IX_medicinPerscriptions_MedicineId",
                table: "medicinPerscriptions",
                column: "MedicineId");

            migrationBuilder.AddForeignKey(
                name: "FK_medicinPerscriptions_medicine_MedicineId",
                table: "medicinPerscriptions",
                column: "MedicineId",
                principalTable: "medicine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_perscription_Doctors_doctorid",
                table: "perscription",
                column: "doctorid",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_perscription_patients_patientid",
                table: "perscription",
                column: "patientid",
                principalTable: "patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_medicinPerscriptions_medicine_MedicineId",
                table: "medicinPerscriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_perscription_Doctors_doctorid",
                table: "perscription");

            migrationBuilder.DropForeignKey(
                name: "FK_perscription_patients_patientid",
                table: "perscription");

            migrationBuilder.DropIndex(
                name: "IX_perscription_doctorid",
                table: "perscription");

            migrationBuilder.DropIndex(
                name: "IX_perscription_patientid",
                table: "perscription");

            migrationBuilder.DropIndex(
                name: "IX_medicinPerscriptions_MedicineId",
                table: "medicinPerscriptions");

            migrationBuilder.DropColumn(
                name: "MedicineId",
                table: "medicinPerscriptions");
        }
    }
}
