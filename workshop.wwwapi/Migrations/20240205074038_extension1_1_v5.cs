using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class extension1_1_v5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_prescription_doctor_id",
                table: "prescription");

            migrationBuilder.DeleteData(
                table: "prescription_medicine",
                keyColumns: new[] { "MedicineId", "PrescriptionId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DropColumn(
                name: "amount",
                table: "medicine");

            migrationBuilder.DropColumn(
                name: "instructions",
                table: "medicine");

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

            migrationBuilder.InsertData(
                table: "prescription",
                columns: new[] { "id", "doctor_id", "name", "patient_id" },
                values: new object[] { 4, 1, "Cure cancer", 5 });

            migrationBuilder.UpdateData(
                table: "prescription_medicine",
                keyColumns: new[] { "MedicineId", "PrescriptionId" },
                keyValues: new object[] { 1, 1 },
                columns: new[] { "amount", "instructions" },
                values: new object[] { 42, "One dose each morning for 3 weeks." });

            migrationBuilder.UpdateData(
                table: "prescription_medicine",
                keyColumns: new[] { "MedicineId", "PrescriptionId" },
                keyValues: new object[] { 2, 1 },
                columns: new[] { "amount", "instructions" },
                values: new object[] { 28, "2 pills each day for 2 weeks." });

            migrationBuilder.UpdateData(
                table: "prescription_medicine",
                keyColumns: new[] { "MedicineId", "PrescriptionId" },
                keyValues: new object[] { 3, 2 },
                columns: new[] { "amount", "instructions" },
                values: new object[] { 10, "5 pills each day for 2 days." });

            migrationBuilder.InsertData(
                table: "prescription_medicine",
                columns: new[] { "MedicineId", "PrescriptionId", "amount", "instructions" },
                values: new object[] { 1, 4, 10, "One dose each morning for 10 days." });

            migrationBuilder.CreateIndex(
                name: "IX_prescription_doctor_id_patient_id",
                table: "prescription",
                columns: new[] { "doctor_id", "patient_id" });

            migrationBuilder.AddForeignKey(
                name: "FK_prescription_appointments_doctor_id_patient_id",
                table: "prescription",
                columns: new[] { "doctor_id", "patient_id" },
                principalTable: "appointments",
                principalColumns: new[] { "doctor_id", "patient_id" },
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_prescription_appointments_doctor_id_patient_id",
                table: "prescription");

            migrationBuilder.DropIndex(
                name: "IX_prescription_doctor_id_patient_id",
                table: "prescription");

            migrationBuilder.DeleteData(
                table: "prescription_medicine",
                keyColumns: new[] { "MedicineId", "PrescriptionId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "prescription",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "amount",
                table: "prescription_medicine");

            migrationBuilder.DropColumn(
                name: "instructions",
                table: "prescription_medicine");

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
                values: new object[] { 1, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_prescription_doctor_id",
                table: "prescription",
                column: "doctor_id");
        }
    }
}
