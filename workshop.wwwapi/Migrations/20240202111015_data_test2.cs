using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class data_test2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumns: new[] { "fk_doctor_id", "fk_patient_id" },
                keyValues: new object[] { 1, 1 },
                column: "date",
                value: new DateTimeOffset(new DateTime(2024, 2, 3, 12, 10, 15, 106, DateTimeKind.Unspecified).AddTicks(8136), new TimeSpan(0, 1, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumns: new[] { "fk_doctor_id", "fk_patient_id" },
                keyValues: new object[] { 1, 2 },
                column: "date",
                value: new DateTimeOffset(new DateTime(2024, 2, 7, 12, 10, 15, 106, DateTimeKind.Unspecified).AddTicks(8144), new TimeSpan(0, 1, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumns: new[] { "fk_doctor_id", "fk_patient_id" },
                keyValues: new object[] { 2, 1 },
                column: "date",
                value: new DateTimeOffset(new DateTime(2024, 5, 2, 12, 10, 15, 106, DateTimeKind.Unspecified).AddTicks(8148), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "doctor_id",
                keyValue: 1,
                column: "full_name",
                value: "Donald Winfrey");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "doctor_id",
                keyValue: 2,
                column: "full_name",
                value: "Kate Hepburn");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "doctor_id",
                keyValue: 3,
                column: "full_name",
                value: "Donald Hepburn");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "doctor_id",
                keyValue: 4,
                column: "full_name",
                value: "Audrey Winslet");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "doctor_id",
                keyValue: 5,
                column: "full_name",
                value: "Audrey Obama");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "doctor_id",
                keyValue: 6,
                column: "full_name",
                value: "Audrey Winfrey");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "doctor_id",
                keyValue: 7,
                column: "full_name",
                value: "Mick Obama");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "doctor_id",
                keyValue: 8,
                column: "full_name",
                value: "Mick Jagger");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "doctor_id",
                keyValue: 9,
                column: "full_name",
                value: "Kate Obama");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "doctor_id",
                keyValue: 10,
                column: "full_name",
                value: "Donald Presley");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "doctor_id",
                keyValue: 11,
                column: "full_name",
                value: "Oprah Winslet");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "doctor_id",
                keyValue: 12,
                column: "full_name",
                value: "Charles Trump");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "doctor_id",
                keyValue: 13,
                column: "full_name",
                value: "Oprah Presley");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "doctor_id",
                keyValue: 14,
                column: "full_name",
                value: "Charles Jagger");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "doctor_id",
                keyValue: 15,
                column: "full_name",
                value: "Barack Trump");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "doctor_id",
                keyValue: 16,
                column: "full_name",
                value: "Jimi Presley");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "doctor_id",
                keyValue: 17,
                column: "full_name",
                value: "Barack Middleton");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "doctor_id",
                keyValue: 18,
                column: "full_name",
                value: "Barack Winfrey");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "doctor_id",
                keyValue: 19,
                column: "full_name",
                value: "Jimi Presley");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "patient_id",
                keyValue: 1,
                column: "full_name",
                value: "Mick Presley");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "patient_id",
                keyValue: 2,
                column: "full_name",
                value: "Mick Hendrix");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "patient_id",
                keyValue: 3,
                column: "full_name",
                value: "Charles Presley");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "patient_id",
                keyValue: 4,
                column: "full_name",
                value: "Audrey Hepburn");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "patient_id",
                keyValue: 5,
                column: "full_name",
                value: "Kate Jagger");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "patient_id",
                keyValue: 6,
                column: "full_name",
                value: "Oprah Winslet");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "patient_id",
                keyValue: 7,
                column: "full_name",
                value: "Kate Windsor");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "patient_id",
                keyValue: 8,
                column: "full_name",
                value: "Audrey Middleton");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "patient_id",
                keyValue: 9,
                column: "full_name",
                value: "Mick Hepburn");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "patient_id",
                keyValue: 10,
                column: "full_name",
                value: "Kate Hendrix");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "patient_id",
                keyValue: 11,
                column: "full_name",
                value: "Oprah Jagger");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "patient_id",
                keyValue: 12,
                column: "full_name",
                value: "Kate Hepburn");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "patient_id",
                keyValue: 13,
                column: "full_name",
                value: "Elvis Windsor");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "patient_id",
                keyValue: 14,
                column: "full_name",
                value: "Oprah Jagger");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "patient_id",
                keyValue: 15,
                column: "full_name",
                value: "Mick Middleton");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "patient_id",
                keyValue: 16,
                column: "full_name",
                value: "Kate Presley");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "patient_id",
                keyValue: 17,
                column: "full_name",
                value: "Oprah Windsor");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "patient_id",
                keyValue: 18,
                column: "full_name",
                value: "Audrey Windsor");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "patient_id",
                keyValue: 19,
                column: "full_name",
                value: "Audrey Hepburn");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_fk_patient_id",
                table: "Appointments",
                column: "fk_patient_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Doctors_fk_doctor_id",
                table: "Appointments",
                column: "fk_doctor_id",
                principalTable: "Doctors",
                principalColumn: "doctor_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Patients_fk_patient_id",
                table: "Appointments",
                column: "fk_patient_id",
                principalTable: "Patients",
                principalColumn: "patient_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Doctors_fk_doctor_id",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Patients_fk_patient_id",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_fk_patient_id",
                table: "Appointments");

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumns: new[] { "fk_doctor_id", "fk_patient_id" },
                keyValues: new object[] { 1, 1 },
                column: "date",
                value: new DateTimeOffset(new DateTime(2024, 2, 3, 12, 2, 19, 544, DateTimeKind.Unspecified).AddTicks(144), new TimeSpan(0, 1, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumns: new[] { "fk_doctor_id", "fk_patient_id" },
                keyValues: new object[] { 1, 2 },
                column: "date",
                value: new DateTimeOffset(new DateTime(2024, 2, 7, 12, 2, 19, 544, DateTimeKind.Unspecified).AddTicks(150), new TimeSpan(0, 1, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumns: new[] { "fk_doctor_id", "fk_patient_id" },
                keyValues: new object[] { 2, 1 },
                column: "date",
                value: new DateTimeOffset(new DateTime(2024, 5, 2, 12, 2, 19, 544, DateTimeKind.Unspecified).AddTicks(153), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "doctor_id",
                keyValue: 1,
                column: "full_name",
                value: "Oprah Obama");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "doctor_id",
                keyValue: 2,
                column: "full_name",
                value: "Charles Winfrey");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "doctor_id",
                keyValue: 3,
                column: "full_name",
                value: "Kate Windsor");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "doctor_id",
                keyValue: 4,
                column: "full_name",
                value: "Kate Hepburn");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "doctor_id",
                keyValue: 5,
                column: "full_name",
                value: "Jimi Presley");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "doctor_id",
                keyValue: 6,
                column: "full_name",
                value: "Jimi Hendrix");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "doctor_id",
                keyValue: 7,
                column: "full_name",
                value: "Kate Hendrix");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "doctor_id",
                keyValue: 8,
                column: "full_name",
                value: "Charles Winfrey");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "doctor_id",
                keyValue: 9,
                column: "full_name",
                value: "Audrey Winfrey");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "doctor_id",
                keyValue: 10,
                column: "full_name",
                value: "Kate Jagger");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "doctor_id",
                keyValue: 11,
                column: "full_name",
                value: "Audrey Presley");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "doctor_id",
                keyValue: 12,
                column: "full_name",
                value: "Mick Presley");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "doctor_id",
                keyValue: 13,
                column: "full_name",
                value: "Jimi Jagger");

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
                value: "Barack Windsor");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "doctor_id",
                keyValue: 17,
                column: "full_name",
                value: "Kate Jagger");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "doctor_id",
                keyValue: 18,
                column: "full_name",
                value: "Barack Jagger");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "doctor_id",
                keyValue: 19,
                column: "full_name",
                value: "Jimi Hendrix");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "patient_id",
                keyValue: 1,
                column: "full_name",
                value: "Kate Windsor");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "patient_id",
                keyValue: 2,
                column: "full_name",
                value: "Donald Obama");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "patient_id",
                keyValue: 3,
                column: "full_name",
                value: "Barack Winslet");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "patient_id",
                keyValue: 4,
                column: "full_name",
                value: "Charles Obama");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "patient_id",
                keyValue: 5,
                column: "full_name",
                value: "Kate Trump");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "patient_id",
                keyValue: 6,
                column: "full_name",
                value: "Barack Middleton");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "patient_id",
                keyValue: 7,
                column: "full_name",
                value: "Kate Obama");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "patient_id",
                keyValue: 8,
                column: "full_name",
                value: "Jimi Winfrey");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "patient_id",
                keyValue: 9,
                column: "full_name",
                value: "Oprah Winslet");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "patient_id",
                keyValue: 10,
                column: "full_name",
                value: "Oprah Winslet");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "patient_id",
                keyValue: 11,
                column: "full_name",
                value: "Elvis Obama");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "patient_id",
                keyValue: 12,
                column: "full_name",
                value: "Barack Winslet");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "patient_id",
                keyValue: 13,
                column: "full_name",
                value: "Donald Presley");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "patient_id",
                keyValue: 14,
                column: "full_name",
                value: "Barack Obama");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "patient_id",
                keyValue: 15,
                column: "full_name",
                value: "Donald Winslet");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "patient_id",
                keyValue: 16,
                column: "full_name",
                value: "Audrey Winslet");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "patient_id",
                keyValue: 17,
                column: "full_name",
                value: "Barack Presley");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "patient_id",
                keyValue: 18,
                column: "full_name",
                value: "Oprah Middleton");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "patient_id",
                keyValue: 19,
                column: "full_name",
                value: "Elvis Hepburn");
        }
    }
}
