using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateToDatatablesMigration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DoctorId",
                table: "appointments",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PatientId",
                table: "appointments",
                type: "integer",
                nullable: true);

            migrationBuilder.InsertData(
                table: "appointments",
                columns: new[] { "booking", "doctor_id_fk", "patient_id_fk", "DoctorId", "id", "PatientId" },
                values: new object[,]
                {
                    { new DateTime(2020, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, null, 3, null },
                    { new DateTime(2020, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, null, 2, null },
                    { new DateTime(2020, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, null, 1, null }
                });

            migrationBuilder.InsertData(
                table: "doctors",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "Dr. Jason Bourne" },
                    { 2, "Dr. Mats Anderson" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_appointments_DoctorId",
                table: "appointments",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_appointments_PatientId",
                table: "appointments",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_appointments_doctors_DoctorId",
                table: "appointments",
                column: "DoctorId",
                principalTable: "doctors",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_appointments_patients_PatientId",
                table: "appointments",
                column: "PatientId",
                principalTable: "patients",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_appointments_doctors_DoctorId",
                table: "appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_appointments_patients_PatientId",
                table: "appointments");

            migrationBuilder.DropIndex(
                name: "IX_appointments_DoctorId",
                table: "appointments");

            migrationBuilder.DropIndex(
                name: "IX_appointments_PatientId",
                table: "appointments");

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "booking", "doctor_id_fk", "patient_id_fk" },
                keyValues: new object[] { new DateTime(2020, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "booking", "doctor_id_fk", "patient_id_fk" },
                keyValues: new object[] { new DateTime(2020, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1 });

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "booking", "doctor_id_fk", "patient_id_fk" },
                keyValues: new object[] { new DateTime(2020, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 });

            migrationBuilder.DeleteData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "doctors",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "appointments");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "appointments");
        }
    }
}
