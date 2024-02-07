using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class test4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PrescriptionMedicines_Prescriptions_fk_prescription_id",
                table: "PrescriptionMedicines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Prescriptions",
                table: "Prescriptions");

            migrationBuilder.RenameTable(
                name: "Prescriptions",
                newName: "prescription");

            migrationBuilder.AddPrimaryKey(
                name: "PK_prescription",
                table: "prescription",
                column: "prescription_id");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "doctor_id",
                keyValue: 1,
                column: "full_name",
                value: "Audrey Hepburn");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "doctor_id",
                keyValue: 2,
                column: "full_name",
                value: "Audrey Windsor");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "doctor_id",
                keyValue: 3,
                column: "full_name",
                value: "Elvis Windsor");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "doctor_id",
                keyValue: 4,
                column: "full_name",
                value: "Charles Jagger");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "doctor_id",
                keyValue: 5,
                column: "full_name",
                value: "Jimi Hepburn");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "doctor_id",
                keyValue: 6,
                column: "full_name",
                value: "Donald Middleton");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "doctor_id",
                keyValue: 7,
                column: "full_name",
                value: "Barack Middleton");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "doctor_id",
                keyValue: 8,
                column: "full_name",
                value: "Audrey Winslet");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "doctor_id",
                keyValue: 9,
                column: "full_name",
                value: "Kate Hepburn");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "doctor_id",
                keyValue: 10,
                column: "full_name",
                value: "Barack Presley");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "doctor_id",
                keyValue: 11,
                column: "full_name",
                value: "Kate Trump");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "doctor_id",
                keyValue: 12,
                column: "full_name",
                value: "Donald Jagger");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "doctor_id",
                keyValue: 13,
                column: "full_name",
                value: "Kate Hepburn");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "doctor_id",
                keyValue: 14,
                column: "full_name",
                value: "Kate Windsor");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "doctor_id",
                keyValue: 15,
                column: "full_name",
                value: "Elvis Presley");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "doctor_id",
                keyValue: 16,
                column: "full_name",
                value: "Barack Presley");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "doctor_id",
                keyValue: 17,
                column: "full_name",
                value: "Elvis Winfrey");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "doctor_id",
                keyValue: 18,
                column: "full_name",
                value: "Jimi Hepburn");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "doctor_id",
                keyValue: 19,
                column: "full_name",
                value: "Donald Presley");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "patient_id",
                keyValue: 1,
                column: "full_name",
                value: "Charles Winslet");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "patient_id",
                keyValue: 2,
                column: "full_name",
                value: "Oprah Hendrix");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "patient_id",
                keyValue: 3,
                column: "full_name",
                value: "Kate Presley");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "patient_id",
                keyValue: 4,
                column: "full_name",
                value: "Oprah Jagger");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "patient_id",
                keyValue: 5,
                column: "full_name",
                value: "Oprah Middleton");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "patient_id",
                keyValue: 6,
                column: "full_name",
                value: "Donald Winfrey");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "patient_id",
                keyValue: 7,
                column: "full_name",
                value: "Audrey Middleton");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "patient_id",
                keyValue: 8,
                column: "full_name",
                value: "Kate Hepburn");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "patient_id",
                keyValue: 9,
                column: "full_name",
                value: "Oprah Trump");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "patient_id",
                keyValue: 10,
                column: "full_name",
                value: "Kate Windsor");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "patient_id",
                keyValue: 11,
                column: "full_name",
                value: "Donald Middleton");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "patient_id",
                keyValue: 12,
                column: "full_name",
                value: "Kate Middleton");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "patient_id",
                keyValue: 13,
                column: "full_name",
                value: "Donald Winfrey");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "patient_id",
                keyValue: 14,
                column: "full_name",
                value: "Charles Obama");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "patient_id",
                keyValue: 15,
                column: "full_name",
                value: "Donald Trump");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "patient_id",
                keyValue: 16,
                column: "full_name",
                value: "Charles Windsor");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "patient_id",
                keyValue: 17,
                column: "full_name",
                value: "Elvis Middleton");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "patient_id",
                keyValue: 18,
                column: "full_name",
                value: "Charles Obama");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "patient_id",
                keyValue: 19,
                column: "full_name",
                value: "Barack Middleton");

            migrationBuilder.AddForeignKey(
                name: "FK_PrescriptionMedicines_prescription_fk_prescription_id",
                table: "PrescriptionMedicines",
                column: "fk_prescription_id",
                principalTable: "prescription",
                principalColumn: "prescription_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PrescriptionMedicines_prescription_fk_prescription_id",
                table: "PrescriptionMedicines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_prescription",
                table: "prescription");

            migrationBuilder.RenameTable(
                name: "prescription",
                newName: "Prescriptions");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Prescriptions",
                table: "Prescriptions",
                column: "prescription_id");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "doctor_id",
                keyValue: 1,
                column: "full_name",
                value: "Jimi Trump");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "doctor_id",
                keyValue: 2,
                column: "full_name",
                value: "Oprah Presley");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "doctor_id",
                keyValue: 3,
                column: "full_name",
                value: "Kate Jagger");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "doctor_id",
                keyValue: 4,
                column: "full_name",
                value: "Kate Windsor");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "doctor_id",
                keyValue: 5,
                column: "full_name",
                value: "Audrey Jagger");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "doctor_id",
                keyValue: 6,
                column: "full_name",
                value: "Donald Jagger");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "doctor_id",
                keyValue: 7,
                column: "full_name",
                value: "Oprah Jagger");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "doctor_id",
                keyValue: 8,
                column: "full_name",
                value: "Jimi Middleton");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "doctor_id",
                keyValue: 9,
                column: "full_name",
                value: "Jimi Windsor");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "doctor_id",
                keyValue: 10,
                column: "full_name",
                value: "Oprah Middleton");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "doctor_id",
                keyValue: 11,
                column: "full_name",
                value: "Charles Jagger");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "doctor_id",
                keyValue: 12,
                column: "full_name",
                value: "Audrey Hepburn");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "doctor_id",
                keyValue: 13,
                column: "full_name",
                value: "Kate Winslet");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "doctor_id",
                keyValue: 14,
                column: "full_name",
                value: "Donald Jagger");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "doctor_id",
                keyValue: 15,
                column: "full_name",
                value: "Donald Obama");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "doctor_id",
                keyValue: 16,
                column: "full_name",
                value: "Mick Obama");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "doctor_id",
                keyValue: 17,
                column: "full_name",
                value: "Audrey Winslet");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "doctor_id",
                keyValue: 18,
                column: "full_name",
                value: "Jimi Trump");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "doctor_id",
                keyValue: 19,
                column: "full_name",
                value: "Charles Presley");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "patient_id",
                keyValue: 1,
                column: "full_name",
                value: "Kate Obama");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "patient_id",
                keyValue: 2,
                column: "full_name",
                value: "Mick Winfrey");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "patient_id",
                keyValue: 3,
                column: "full_name",
                value: "Oprah Winslet");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "patient_id",
                keyValue: 4,
                column: "full_name",
                value: "Mick Winslet");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "patient_id",
                keyValue: 5,
                column: "full_name",
                value: "Charles Winslet");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "patient_id",
                keyValue: 6,
                column: "full_name",
                value: "Jimi Hendrix");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "patient_id",
                keyValue: 7,
                column: "full_name",
                value: "Kate Jagger");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "patient_id",
                keyValue: 8,
                column: "full_name",
                value: "Donald Hepburn");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "patient_id",
                keyValue: 9,
                column: "full_name",
                value: "Barack Obama");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "patient_id",
                keyValue: 10,
                column: "full_name",
                value: "Barack Windsor");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "patient_id",
                keyValue: 11,
                column: "full_name",
                value: "Oprah Middleton");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "patient_id",
                keyValue: 12,
                column: "full_name",
                value: "Elvis Windsor");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "patient_id",
                keyValue: 13,
                column: "full_name",
                value: "Barack Hepburn");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "patient_id",
                keyValue: 14,
                column: "full_name",
                value: "Audrey Windsor");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "patient_id",
                keyValue: 15,
                column: "full_name",
                value: "Oprah Winslet");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "patient_id",
                keyValue: 16,
                column: "full_name",
                value: "Mick Trump");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "patient_id",
                keyValue: 17,
                column: "full_name",
                value: "Donald Hendrix");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "patient_id",
                keyValue: 18,
                column: "full_name",
                value: "Barack Hepburn");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "patient_id",
                keyValue: 19,
                column: "full_name",
                value: "Oprah Trump");

            migrationBuilder.AddForeignKey(
                name: "FK_PrescriptionMedicines_Prescriptions_fk_prescription_id",
                table: "PrescriptionMedicines",
                column: "fk_prescription_id",
                principalTable: "Prescriptions",
                principalColumn: "prescription_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
