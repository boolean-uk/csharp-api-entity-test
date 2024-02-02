using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class extension1_1_v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_prescription_medicine_medicine_medicine_id",
                table: "prescription_medicine");

            migrationBuilder.DropForeignKey(
                name: "FK_prescription_medicine_prescription_prescription_id",
                table: "prescription_medicine");

            migrationBuilder.DropColumn(
                name: "amount",
                table: "prescription_medicine");

            migrationBuilder.DropColumn(
                name: "instructions",
                table: "prescription_medicine");

            migrationBuilder.RenameColumn(
                name: "medicine_id",
                table: "prescription_medicine",
                newName: "MedicineId");

            migrationBuilder.RenameColumn(
                name: "prescription_id",
                table: "prescription_medicine",
                newName: "PrescriptionId");

            migrationBuilder.RenameIndex(
                name: "IX_prescription_medicine_medicine_id",
                table: "prescription_medicine",
                newName: "IX_prescription_medicine_MedicineId");

            migrationBuilder.AddColumn<int>(
                name: "DoctorId",
                table: "prescription",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PatientId",
                table: "prescription",
                type: "integer",
                nullable: true);

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

            migrationBuilder.InsertData(
                table: "medicine",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "Vitalysol" },
                    { 2, "Zypherexa" },
                    { 3, "Pheonixal" }
                });

            migrationBuilder.InsertData(
                table: "prescription",
                columns: new[] { "id", "amount", "DoctorId", "instructions", "name", "PatientId" },
                values: new object[,]
                {
                    { 1, 42, null, "One dose each morning for 3 weeks.", "Preventative care", null },
                    { 2, 28, null, "2 pills each day for 2 weeks.", "Cure Infection", null }
                });

            migrationBuilder.InsertData(
                table: "prescription_medicine",
                columns: new[] { "MedicineId", "PrescriptionId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 3, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_prescription_DoctorId",
                table: "prescription",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_prescription_PatientId",
                table: "prescription",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_prescription_doctors_DoctorId",
                table: "prescription",
                column: "DoctorId",
                principalTable: "doctors",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_prescription_patients_PatientId",
                table: "prescription",
                column: "PatientId",
                principalTable: "patients",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_prescription_medicine_medicine_MedicineId",
                table: "prescription_medicine",
                column: "MedicineId",
                principalTable: "medicine",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_prescription_medicine_prescription_PrescriptionId",
                table: "prescription_medicine",
                column: "PrescriptionId",
                principalTable: "prescription",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_prescription_doctors_DoctorId",
                table: "prescription");

            migrationBuilder.DropForeignKey(
                name: "FK_prescription_patients_PatientId",
                table: "prescription");

            migrationBuilder.DropForeignKey(
                name: "FK_prescription_medicine_medicine_MedicineId",
                table: "prescription_medicine");

            migrationBuilder.DropForeignKey(
                name: "FK_prescription_medicine_prescription_PrescriptionId",
                table: "prescription_medicine");

            migrationBuilder.DropIndex(
                name: "IX_prescription_DoctorId",
                table: "prescription");

            migrationBuilder.DropIndex(
                name: "IX_prescription_PatientId",
                table: "prescription");

            migrationBuilder.DeleteData(
                table: "medicine",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "prescription_medicine",
                keyColumns: new[] { "MedicineId", "PrescriptionId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "prescription_medicine",
                keyColumns: new[] { "MedicineId", "PrescriptionId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "prescription_medicine",
                keyColumns: new[] { "MedicineId", "PrescriptionId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "medicine",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "medicine",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "prescription",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "prescription",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "prescription");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "prescription");

            migrationBuilder.DropColumn(
                name: "amount",
                table: "prescription");

            migrationBuilder.DropColumn(
                name: "instructions",
                table: "prescription");

            migrationBuilder.RenameColumn(
                name: "MedicineId",
                table: "prescription_medicine",
                newName: "medicine_id");

            migrationBuilder.RenameColumn(
                name: "PrescriptionId",
                table: "prescription_medicine",
                newName: "prescription_id");

            migrationBuilder.RenameIndex(
                name: "IX_prescription_medicine_MedicineId",
                table: "prescription_medicine",
                newName: "IX_prescription_medicine_medicine_id");

            migrationBuilder.AddColumn<int>(
                name: "amount",
                table: "prescription_medicine",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "instructions",
                table: "prescription_medicine",
                type: "character varying(511)",
                maxLength: 511,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_prescription_medicine_medicine_medicine_id",
                table: "prescription_medicine",
                column: "medicine_id",
                principalTable: "medicine",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_prescription_medicine_prescription_prescription_id",
                table: "prescription_medicine",
                column: "prescription_id",
                principalTable: "prescription",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
