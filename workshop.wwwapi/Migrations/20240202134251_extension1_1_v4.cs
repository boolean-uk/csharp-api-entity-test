using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class extension1_1_v4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_prescription_doctors_DoctorId",
                table: "prescription");

            migrationBuilder.DropForeignKey(
                name: "FK_prescription_patients_PatientId",
                table: "prescription");

            migrationBuilder.RenameColumn(
                name: "PatientId",
                table: "prescription",
                newName: "patient_id");

            migrationBuilder.RenameColumn(
                name: "DoctorId",
                table: "prescription",
                newName: "doctor_id");

            migrationBuilder.RenameIndex(
                name: "IX_prescription_PatientId",
                table: "prescription",
                newName: "IX_prescription_patient_id");

            migrationBuilder.RenameIndex(
                name: "IX_prescription_DoctorId",
                table: "prescription",
                newName: "IX_prescription_doctor_id");

            migrationBuilder.AlterColumn<int>(
                name: "patient_id",
                table: "prescription",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "doctor_id",
                table: "prescription",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "prescription",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "doctor_id", "patient_id" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "prescription",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "doctor_id", "patient_id" },
                values: new object[] { 3, 5 });

            migrationBuilder.InsertData(
                table: "prescription",
                columns: new[] { "id", "doctor_id", "name", "patient_id" },
                values: new object[] { 3, 1, "Cure cancer", 5 });

            migrationBuilder.AddForeignKey(
                name: "FK_prescription_doctors_doctor_id",
                table: "prescription",
                column: "doctor_id",
                principalTable: "doctors",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_prescription_patients_patient_id",
                table: "prescription",
                column: "patient_id",
                principalTable: "patients",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_prescription_doctors_doctor_id",
                table: "prescription");

            migrationBuilder.DropForeignKey(
                name: "FK_prescription_patients_patient_id",
                table: "prescription");

            migrationBuilder.DeleteData(
                table: "prescription",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.RenameColumn(
                name: "patient_id",
                table: "prescription",
                newName: "PatientId");

            migrationBuilder.RenameColumn(
                name: "doctor_id",
                table: "prescription",
                newName: "DoctorId");

            migrationBuilder.RenameIndex(
                name: "IX_prescription_patient_id",
                table: "prescription",
                newName: "IX_prescription_PatientId");

            migrationBuilder.RenameIndex(
                name: "IX_prescription_doctor_id",
                table: "prescription",
                newName: "IX_prescription_DoctorId");

            migrationBuilder.AlterColumn<int>(
                name: "PatientId",
                table: "prescription",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "DoctorId",
                table: "prescription",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.UpdateData(
                table: "prescription",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "DoctorId", "PatientId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "prescription",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "DoctorId", "PatientId" },
                values: new object[] { null, null });

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
        }
    }
}
