using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace workshop.wwwapi.Migrations
{
    /// <inheritdoc />
    public partial class mig3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_appointments_doctors_DoctorId",
                table: "appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_appointments_patients_PatientId",
                table: "appointments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PrescriptionMedicines",
                table: "PrescriptionMedicines");

            migrationBuilder.DropIndex(
                name: "IX_PrescriptionMedicines_PerscriptionId",
                table: "PrescriptionMedicines");

            migrationBuilder.DropIndex(
                name: "IX_Perscriptions_AppointmentId",
                table: "Perscriptions");

            migrationBuilder.DeleteData(
                table: "PrescriptionMedicines",
                keyColumns: new[] { "MedicinesId", "PerscriptionId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "PrescriptionMedicines",
                keyColumns: new[] { "MedicinesId", "PerscriptionId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.RenameColumn(
                name: "PatientId",
                table: "appointments",
                newName: "patient_Id");

            migrationBuilder.RenameColumn(
                name: "DoctorId",
                table: "appointments",
                newName: "doctor_Id");

            migrationBuilder.RenameIndex(
                name: "IX_appointments_PatientId",
                table: "appointments",
                newName: "IX_appointments_patient_Id");

            migrationBuilder.RenameIndex(
                name: "IX_appointments_DoctorId",
                table: "appointments",
                newName: "IX_appointments_doctor_Id");

            migrationBuilder.AddColumn<int>(
                name: "perscription_Id",
                table: "appointments",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PrescriptionMedicines",
                table: "PrescriptionMedicines",
                columns: new[] { "PerscriptionId", "MedicinesId" });

            migrationBuilder.InsertData(
                table: "PrescriptionMedicines",
                columns: new[] { "MedicinesId", "PerscriptionId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 }
                });

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumn: "appointment_Id",
                keyValue: 1,
                columns: new[] { "booking_time", "perscription_Id" },
                values: new object[] { new DateTime(2024, 9, 9, 12, 42, 50, 539, DateTimeKind.Utc).AddTicks(9042), 0 });

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumn: "appointment_Id",
                keyValue: 2,
                columns: new[] { "booking_time", "perscription_Id" },
                values: new object[] { new DateTime(2024, 9, 9, 12, 42, 50, 539, DateTimeKind.Utc).AddTicks(9044), 0 });

            migrationBuilder.CreateIndex(
                name: "IX_PrescriptionMedicines_MedicinesId",
                table: "PrescriptionMedicines",
                column: "MedicinesId");

            migrationBuilder.CreateIndex(
                name: "IX_Perscriptions_AppointmentId",
                table: "Perscriptions",
                column: "AppointmentId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_appointments_doctors_doctor_Id",
                table: "appointments",
                column: "doctor_Id",
                principalTable: "doctors",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_appointments_patients_patient_Id",
                table: "appointments",
                column: "patient_Id",
                principalTable: "patients",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_appointments_doctors_doctor_Id",
                table: "appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_appointments_patients_patient_Id",
                table: "appointments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PrescriptionMedicines",
                table: "PrescriptionMedicines");

            migrationBuilder.DropIndex(
                name: "IX_PrescriptionMedicines_MedicinesId",
                table: "PrescriptionMedicines");

            migrationBuilder.DropIndex(
                name: "IX_Perscriptions_AppointmentId",
                table: "Perscriptions");

            migrationBuilder.DeleteData(
                table: "PrescriptionMedicines",
                keyColumns: new[] { "MedicinesId", "PerscriptionId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "PrescriptionMedicines",
                keyColumns: new[] { "MedicinesId", "PerscriptionId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DropColumn(
                name: "perscription_Id",
                table: "appointments");

            migrationBuilder.RenameColumn(
                name: "patient_Id",
                table: "appointments",
                newName: "PatientId");

            migrationBuilder.RenameColumn(
                name: "doctor_Id",
                table: "appointments",
                newName: "DoctorId");

            migrationBuilder.RenameIndex(
                name: "IX_appointments_patient_Id",
                table: "appointments",
                newName: "IX_appointments_PatientId");

            migrationBuilder.RenameIndex(
                name: "IX_appointments_doctor_Id",
                table: "appointments",
                newName: "IX_appointments_DoctorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PrescriptionMedicines",
                table: "PrescriptionMedicines",
                columns: new[] { "MedicinesId", "PerscriptionId" });

            migrationBuilder.InsertData(
                table: "PrescriptionMedicines",
                columns: new[] { "MedicinesId", "PerscriptionId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 }
                });

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumn: "appointment_Id",
                keyValue: 1,
                column: "booking_time",
                value: new DateTime(2024, 9, 9, 8, 28, 39, 629, DateTimeKind.Utc).AddTicks(1837));

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumn: "appointment_Id",
                keyValue: 2,
                column: "booking_time",
                value: new DateTime(2024, 9, 9, 8, 28, 39, 629, DateTimeKind.Utc).AddTicks(1842));

            migrationBuilder.CreateIndex(
                name: "IX_PrescriptionMedicines_PerscriptionId",
                table: "PrescriptionMedicines",
                column: "PerscriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Perscriptions_AppointmentId",
                table: "Perscriptions",
                column: "AppointmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_appointments_doctors_DoctorId",
                table: "appointments",
                column: "DoctorId",
                principalTable: "doctors",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_appointments_patients_PatientId",
                table: "appointments",
                column: "PatientId",
                principalTable: "patients",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
